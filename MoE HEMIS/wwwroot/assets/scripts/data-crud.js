
var selectedrow;



//Load data from remote and populate table
loadAndPopulateData(url, tableId, columns)




//Add New Data

$(newformId).on("submit", function (event) {
    event.preventDefault();
    addNewData(url, $(this), table)
});




// Delete Data

$(tableId).on('click', '.delete-data-button', function () {
    deleteData($(this))
})


$(tableId).on('click', '.edit-data-button', function () {

    onEditButtonClicked($(this))

})

$(editformId).on("submit", function (event) {
    event.preventDefault();
    editData($(this))

});








//Load Data

function loadAndPopulateData(url, tableId, columns) {


    $(document).ready(function () {
        var dataUrl = url
        if (typeof fetchUrl !== 'undefined') {
            dataUrl = fetchUrl
        }
        
        table = $(tableId).DataTable({
            ajax: {
                url: dataUrl,
                dataSrc: "",
            },
            dom: 'Brftip',
            columns: columns,
            buttons: [
                'copy', 'csv', 'excel', 'pdf'
            ]

        })

    })


}

// Add Data

function addNewData(url, form, table) {
    var data = getFormData(form);
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            table.row.add(response).draw()
            toastr.success('Added!');
        },
    });
}

// Delete Data
function deleteData(button) {
    var deleteFlag = confirm("Are you sure you want to delete?")

    if (!deleteFlag) {
        return
    }

    var id = button.attr('data-model-id')
    $.ajax({
        type: "DELETE",
        url: url + "/" + id,
        success: function (response) {
            table.row(button.parents("tr")).remove().draw()
            toastr.error('Deleted!');
        },
    });
}

// On Edit Button Clicked

function onEditButtonClicked(button) {

    selectedrow = table.row(button.parents("tr"))
    var data = table.row(button.parents("tr")).data()

    var $inputs = $(editformId + ' input, ' + editformId + ' select');
    $.each(data, function (key, value) {
        $inputs.filter(function () {
            return key == this.name;
        }).val(value);
    });
}


// Edit Data

function editData(form) {

    var data = getFormData(form);


    $.ajax({
        type: "PUT",
        url: url + "/" + data[dataId],
        data: JSON.stringify(data),
        contentType: "application/json",
        success: function (response) {
            selectedrow.remove()
            table.row.add(response).draw()
            $('#edit-model-modal').modal('toggle');
            toastr.info('Edited!');
        },
    });
}

//Parse Form Data to Json
function getFormData($form) {
    var unindexed_array = $form.serializeArray();
    var indexed_array = {};

    $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}