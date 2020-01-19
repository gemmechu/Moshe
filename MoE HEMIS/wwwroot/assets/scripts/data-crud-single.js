
    $(editformId).on("submit", function (event) {
        event.preventDefault();
    editData($(this))

});

        $(document).ready(function () {
            var dataUrl = url
            if (typeof fetchUrl !== 'undefined') {
        dataUrl = fetchUrl
    }

    getAndPopulateData()
    }
)

    //populate data
            function populateData(data) {

                var $inputs = $(editformId + ' input, ' + editformId + ' select');
                $.each(data, function (key, value) {
        $inputs.filter(function () {
            return key == this.name;
        }).val(value);

    })
}

//Get Data
            function getAndPopulateData() {
        $.ajax({
            type: "GET",
            dataType: 'json', // added data type
            url: fetchUrl,
            success: function (response) {
                if (response != null) {
                    populateData(response)
                }
            },
        });
    }
    // Edit Data

            function editData(form) {

                var data = getFormData(form);
    console.log(data)

                $.ajax({
        type: "PUT",
    url: url,
    data: JSON.stringify(data),
    contentType: "application/json",
                    success: function (response) {
        populateData(response)
                        $('#edit-model-modal').modal('toggle');
    toastr.info('Edited!');
},
                    error: function (error) {
        console.log(error)
    }
    });
}

// On Edit Button Clicked



//Parse Form Data to Json
        function getFormData($form) {
            var unindexed_array = $form.serializeArray();
            var indexed_array = {};

            $.map(unindexed_array, function (n, i) {
        indexed_array[n['name']] = n['value'];
    });

    return indexed_array;
}
