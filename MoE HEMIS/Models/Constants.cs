using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoE_HEMIS.Models
{
    public class Constants
{
}

    public enum StudyLeaveReason
    {
        MASTERS, PHD, SPECIALITY, SUBSPECIALITY, OTHERS

    }

    public enum StudyLocation
    {
        ETHIOPIA, ABROAD
    }

    public enum AdministrativeAndSupportiveStaffLevel
    {
        DIPLOMA,
        ADVANCED_DIPLOMA,
        BACHELORS,
        MD_DV,
        MASTERS,
        PHD,
        SPECIALITY,
        SUB_SPECIALITY,

        Grade_10,
        Grade_11,
        Grade_12,
        Grade_10_1,
        Grade_10_2,
        Grade_10_3,

        Level_I,
        Level_II,
        Level_III,
        Level_IV,
        Level_V
    }

    public enum StaffDedication
    {
        FULLTIME, PARTTIME
    }

    public enum Region
    {
        ADDISABABA, //0
        AMHARA,
        DIREDAWA,
        HARAR,
        TIGRAY, //4

        //Emerging Areas
        AFAR, // 5
        GAMBELA,
        BENISHANGULGUMUZ,
        SOMALI, //8

        //Pastoral Areas
        OROMIA,
        SNNP //10
    }



    public enum StudyYear
    {
        I, II, III, IV, V
    }
    public enum StudyProgram
    {
        DAYTIME,
        SUMMER,
        EXTENSION,
        DISTANCE,
        REGULAR
    }

    public enum StudyLevel
    {
        UNDERGRADUATE,
        MASTERS,
        PHD,
        SPECIALIZATION,
        SUBSPECIALIZATION
    }

    public enum AgeRange
    {
        LESSTHANEIGHTEEN,
        EIGHTEEN,
        NINETEEN,
        TWENTY,
        TWENTYONE,
        TWENTYTWO,
        TWENTYTHREE,
        TWENTYFOUR,
        TWENTYFIVE,
        TWENTYSIX,
        GRATERTHANTWENTYSIX
    }

    public enum ManagementLevel
    {
        TOP_LEVEL,
        MIDDLE_LEVEL,
        LOWER_LEVEL
    }

    public enum ResearchStatus
    {
        ONGOING, COMPLETED
    }

    public enum ProgramType
    {
        TEACHERS_PARTICIPATION_IN_COMPREHENSIVE_CONTINUOUS_PROFESSIONAL_DEVELOPMENT,
        TEACHERS_PARTICIPATION_IN_HIGHER_DIPLOMA_PROGRAM,
        TEACHERS_PARTICIPATION_IN_ENGLISH_LANGUAGE_IMPROVEMENT_PROGRAM

    }

    public enum ProgramStatus
    {
        COMPLETED,
        ON_TRAINING,
        NOT_YET_STARTED
    }

    public enum TrainingType
    {
        DIPLOMA_TRAINING_IN_TEACHING,
        DIPLOMA_TRAINING_FOR_SCHOOL_LEADERS
    }

    public enum TrainingStatus
    {
        REGULAR,
        NOT_REGULAR
    }

    public enum StudentAttritionCase
    {
        ACADEMIC_DISMISSALS_WITH_READMITION,
        ACADEMIC_DISMISSALS_FOR_GOOD,
        DISCIPLINE_DISMISSALS,
        WITHDRAWALS,
        DROPOUTS,
        OTHERS
    }

    public enum EconomicQuintile
    {
        LOW, SECOND, THIRD, FOURTH, HIGH
    }

    public enum Publication
    {
        JOURNAL, PATENT
    }
}
