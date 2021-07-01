// change host name for test use
var HostName = "localhost:44343";

// var HostName = "localhost";


var TableDataURL = "https://" + HostName + "/home/GetStudentData";
var DeleteStudentID = "0";
var UpdateStudentURL = "https://" + HostName + "/home/UpdateStudentData";
var CreateStudentURL = "https://" + HostName + "/home/CreateStudentData";
var DeleteStudentURL = "https://" + HostName + "/home/DeleteStudentData";
var StudentDataTableNew;
var StudentListArray = [];

function GetAllStudentsData(Data) {

    jQuery.ajaxSetup({ async: false, cache: false });
    $.ajax({
        type: 'POST',
        url: TableDataURL,
        data: {
            'FilterData': Data},
        cache: false,
        success: function (Data) {
        },
        error: function (Data) {
            console.log("Failed to Student Data.");
            return false;
        }
    });

}

function DeleteStudentsData(id) {

    jQuery.ajaxSetup({ async: false, cache: false });
    $.ajax({
        type: 'POST',
        url: DeleteStudentURL,
        data: { "StudentId": id },
        cache: false,
        success: function (Data) {
            console.log("Id deleted");
            $("#FilterDataSearch").trigger("click");
        },
        error: function (Data) {
            console.log("Failed to delete Student Data.");
            return false;
        }
    });

}

function UpdateStudentInfo(oStudentData) {
    jQuery.ajaxSetup({ async: false, cache: false });
    $.ajax({
        type: 'POST',
        url: UpdateStudentURL,
        data: {"oStudentDetail" :oStudentData},
        cache: false,
        success: function (Data) {
            console.log("Student Updated");
            $("#FilterDataSearch").trigger("click");
        },
        error: function (Data) {
            console.log("Failed to delete Student Data.");
            return false;
        }
    });


}

function CreateStudentInfo(oStudentData) {
    jQuery.ajaxSetup({ async: false, cache: false });
    $.ajax({
        type: 'POST',
        url: CreateStudentURL,
        data: { "oStudentDetail": oStudentData },
        cache: false,
        success: function (Data) {
            console.log("Student Created");
            $("#FilterDataSearch").trigger("click");
        },
        error: function (Data) {
            console.log("Failed to delete Student Data.");
            return false;
        }
    });


}


function ReturnTableRowString(Data) {
    var ReturnString = "";
    if (Data != null && Data != undefined) {
        for (var i = 0; i < Data.length; i++) {

            ReturnString = ReturnString + '<tr class="selected">' +
                '     <td class ="id " value="' + Data[i].StudentID + '"> ' + Data[i].StudentID + ' </td>' +          //ID
                '     <td class ="FirstName ">' + Data[i].FirstName + '</td>     ' +                  //FirstName
                '     <td class ="LastName ">' + Data[i].LastName + '</td>     ' +                   //Last Name
                '     <td class = "Class "> ' + Data[i].Class + ' </td>      ' +                   //Class
                returnSubjectData(Data[i].SubjectList) +      // Subject Marks
                '     <td>' +
                '         <button type="button" class="btn btn-primary mr-1" data-toggle="modal" data-target="#editStudentData">Edit</button>' +
                '         <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#deleteStudentData">Delete</button>    ' +
                '     </td>' +
                ' </tr>';


            return ReturnString;
        }
    }
}


function ActionColumnDataString() {
    
    return '<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#editStudentData">Edit</button>' +
           '<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#deleteStudentData">Delete</button>';

}

function returnSubjectData(SubjectList) {

    var SubjectTableString = "";
    if (SubjectList !== "" && SubjectList != null && SubjectList != undefined && SubjectList.length != 0) {



        for (var x = 0; x < SubjectList.length; x++) {
            SubjectTableString = SubjectTableString +
                '<tr >  <td class="Subject">' + SubjectList[x].Subject + '</td>' +
                '<td class="Subject">' + SubjectList[x].SubjectMarks + '</td>   </tr>';
        }
        SubjectTableString = '<table class="table table-bordered SubjectMarks"><th colspan="3"><td>Subjects</td>  <td> Marks</td></th> <tr>' + SubjectTableString + '</tr> </table>';

        return SubjectTableString;
    }
    else {
        SubjectTableString ='<tr >  <td class="Subject">-</td> <td class="Subject">-</td>   </tr>';
        SubjectTableString = '<table class="table table-bordered SubjectMarks"><th colspan="3"><td>Subjects</td>  <td> Marks</td></th> <tr>' + SubjectTableString + '</tr> </table>';
        return SubjectTableString;
    }

}


function AddSubject(C) {
    if ($("#" + C + " [name='StudentSubject'] ") !== undefined && $("#" + C + " [name='StudentSubject'] ").length > 2) {

    }
    else {
        $("#" + C).html($("#" + C).html()                             +
            ' <div class="subjectBlockClass"><label for="StudentSubject">Subject:</label>                                              ' +
            '    <div class="form-group" name="SubjectType">                                             ' +
            '        <select class="SubjectSelectDrop form-control" name="StudentSubject">              ' +
            '            <option value="English">English</option>                                        ' +
            '            <option value="Maths">Maths</option>                                            ' +
            '            <option value="Science">Science</option>                                        ' +
            '        </select>                                                                           ' +
            '        <br>                                                                                ' +
            '        <input type="number" min="1" max="100" class="StudentMarks form-control Marks" placeholder="Marks" name="Marks" autocomplete="off" value="0">     ' +
            '    </div> <button class="btn btn-default btn-sm RemoveSubjectButton">Remove Subject</button> </div> ');

        ;
    }
}



//Function returns ajax data for JqueryData Table
function AjaxDataForDataTable(strUrl, strJsonString) {
    // If string is empty
    if (strJsonString == undefined || strJsonString == null) {
        strJsonString = "";
    }

    var AjaxJson = {
        "url": strUrl,
        "datatype": "json",
        "data": strJsonString,
        cache: false,
        complete: function (response) {
            console.log(response);
        }
    };

    return AjaxJson;
}

// Constant Options in Jquery Table 
var ConstantOptions = {
    responsive: true,
    scrollX: false,
    "searching": false,
    //"lengthMenu": [[10, 20, 50], [10, 20, 50]], // [[10, 20, -1], [10, 20, "All"]],
    "processing": true,
    "serverSide": true,
    "bPaginate": true,
    "sPaginationType": "simple_numbers",
    "sServerMethod": "POST",
    "paging": true,
    "stateSave": false,
    "lengthChange": true,
    "info": true,
    "bFilter": true,
    "cache": false,
    "destroy": true

    // Save the table page position,sorting etc.
    , "stateSave": true
    , "stateDuration": -1
};


function ReturnFilterDataJsonString(Data) {

    //var Type = $('select#SelectedFilter option:selected').val(); ;
    //var Query = $("#StudentSearch").val();
    //if (Query != "" && Query != null && Query != undefined) {

    //    return JSON.stringify({ FilterType: Type, FilterQuery: Query });

    //}
    //else {
    //    return JSON.stringify({ FilterType: "", FilterQuery: "" });
    //}

    return { 'FilterData': Data };
}



// Initialize Table New
function StudentTableInitialize(FilterData) {
    var TableProperties = {
        columnDefs: [
            { responsivePriority: 1, targets: -6, orderable: false },                    // Student ID
            { responsivePriority: 2, targets: -5,  orderable: true },                    // First Name
            { responsivePriority: 3, targets: -4,  orderable: true },                    // Last Name
            { responsivePriority: 4, targets: -3, orderable: true },                   // Class
            { responsivePriority: 5, targets: -2, orderable: false },                   // Subject Marks
            { responsivePriority: 6, targets: -1, orderable: true },                   // Actions
        ],
        "order": [[2, "asc"]],
        "ajax": AjaxDataForDataTable(TableDataURL, ReturnFilterDataJsonString(FilterData)),
        "columns": [
                    /*0*/ { "data": "StudentId" },                      // Student ID
                    /*1*/ { "data": "FirstName" },                      // First Name
                    /*2*/ { "data": "LastName" },                        // Last Name
                    /*3*/ { "data": "Class" },                     // Class
                    /*4*/ { "data": "Subject" },              // Sibject Marks
                    /*5*/ { "data": "Actions" },                  // Actions
        ],                                                            
        "fnRowCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {


            StudentListArray.push(aData);

            if (aData != undefined && aData != null && aData != "") { 
            // Student  info
                $('td:eq(0)', nRow).addClass("StudentDataId").html('<a href="javascript:void(0);"> ' + aData.StudentId + '</a>');
                $('td:eq(0)', nRow).parent().data(aData);
                $('td:eq(0)', nRow).parent().addClass("StudentMainTableRow");
            $('td:eq(1)', nRow).addClass("StudentDataFirstName").html('<a href="javascript:void(0);"> ' + aData.FirstName + '</a>');
            $('td:eq(2)', nRow).addClass("StudentDataLastName").html('<a href="javascript:void(0);"> ' + aData.LastName + '</a>');
            $('td:eq(3)', nRow).addClass("StudentDataClass").html('<a href="javascript:void(0);"> ' + aData.Class + '</a>');

            // Provider info
                $('td:eq(4)', nRow).addClass("StudentSubjects").html(returnSubjectAndMarks(aData.SubjectDataList));

                
            }


            


        },
        "initComplete": function (settings, json) {
            AddActionButtonsToTable();
        },

    };
    // Merge Table options With constant data
    var FinalTableOptions = $.extend(ConstantOptions, TableProperties);

    StudentDataTableNew = $('#StudentDataTable').DataTable(FinalTableOptions);

    
    
}

function PlaceRowDataInUpdateBox(DataObj) {
    
    $("#SubjectBlock").html("");
    // 

    $("#ModalHeaderStudentId").html(DataObj.StudentId);

    $("#FirstName").val(DataObj.FirstName);

    $("#LastName").val(DataObj.LastName);
    
    $("#ClassSelect").val(DataObj.Class);

    for (var Sub = 0; Sub < DataObj.SubjectDataList.length; Sub++) {

        $("#AddSubjectButton").trigger("click");
    }
    for (var Sub = 0; Sub < DataObj.SubjectDataList.length; Sub++) {
        $("#SubjectBlock .subjectBlockClass:nth-child(" + (Sub + 1) + ")").find(".SubjectSelectDrop").val(DataObj.SubjectDataList[Sub].SubjectName);
        $("#SubjectBlock .subjectBlockClass:nth-child(" + (Sub + 1) + ")").find('[placeholder="Marks"]').val(DataObj.SubjectDataList[Sub].SubjectMarks);
    }


}


function AddActionButtonsToTable() {
    var TotalRows = $("#StudentDataTableBody tr").length;

    if (TotalRows != 0 && TotalRows != undefined) {
        for (var r = 1; r <= TotalRows; r++) {

            $("#StudentDataTableBody .StudentMainTableRow:nth-child(" + r + ") td").last().html(ActionColumnDataString());
        }

    }
}


function returnSubjectAndMarks(SubjectList) {
    var SubjectDataString = "";
    if (SubjectList != undefined && SubjectList != null && SubjectList.length != 0) {
        for (var s = 0; s < SubjectList.length; s++) {
            SubjectDataString = SubjectDataString + ' <tr number="'+s+'">                ' +
                '     <td class="' + SubjectList[s].SubjectName +' SubjectName">' + SubjectList[s].SubjectName +'</td>  ' +
                                                     '     <td>-</td>      ' +
                '     <td class="SubjectMarks">' + SubjectList[s].SubjectMarks +'</td>     ' +
                                                     '  </tr>              ';

        }
    }

    return '<table>' + SubjectDataString+'</table>';
}


function GetStudentDetailsData() {
    var Arr = [];

    for (var Sub = 0; Sub < $("#SubjectBlock .subjectBlockClass").length; Sub++) {
        
        var TempObj = {
            StudentId:$("#ModalHeaderStudentId").html() ,

            SubjectName:$("#SubjectBlock .subjectBlockClass:nth-child(" + (Sub + 1) + ")").find(".SubjectSelectDrop").val() ,

            SubjectMarks:$("#SubjectBlock .subjectBlockClass:nth-child(" + (Sub + 1) + ")").find('[placeholder="Marks"]').val()
        }

        Arr.push(TempObj);
    }

    var DataObj = {


        StudentId : $("#ModalHeaderStudentId").html(),

        FirstName : $("#FirstName").val(),

        LastName : $("#LastName").val(),

        Class : $("#ClassSelect").val(),

        SubjectDataList: Arr

    };

    return DataObj;
}


function CreateStudentDetailsData() {
    var CArr = [];

    for (var Sub = 0; Sub < $("#CSubjectBlock .subjectBlockClass").length; Sub++) {

        var CTempObj = {

            SubjectName: $("#CSubjectBlock .subjectBlockClass:nth-child(" + (Sub + 1) + ")").find(".SubjectSelectDrop").val(),

            SubjectMarks: $("#CSubjectBlock .subjectBlockClass:nth-child(" + (Sub + 1) + ")").find('[placeholder="Marks"]').val()
        }

        CArr.push(CTempObj);
    }

    var CDataObj = {



        FirstName: $("#CFirstName").val(),

        LastName: $("#CLastName").val(),

        Class: $("#CClassSelect").val(),

        SubjectDataList: CArr

    };

    return CDataObj;
}

function ClearInputs() {
    $("#CFirstName").val("");

    $("#CLastName").val("");

    $("#CClassSelect").val("1");

    $("#CSubjectBlock").html("");
}


function CStudentDetailValidation() {
    var Validation = false;

    if ($("#CLastName").val().trim() != "" && $("#CFirstName").trim() != "") {
        Validation = true;
    }

    return Validation;
}


function UStudentDetailValidation() {
    var UValidation = false;

    if ($("#LastName").val().trim() != "" && $("#FirstName").trim() != "") {
        UValidation = true;
    }

    return UValidation;
}


function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function getCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    document.cookie = name + '=; Path=/; Expires=Thu, 01 Jan 1970 00:00:01 GMT;';
}

$(document).ready(function () {
    $.fn.dataTable.ext.errMode = 'none';
    //GetAllStudentsData();
    StudentTableInitialize();



    $('#myModal').modal({ backdrop: 'static', keyboard: false });
    $("#AddSubjectButton").unbind();

    $("#CAddSubjectButton").unbind();

    $("#SubjectBlock").on("click", ".RemoveSubjectButton",(function () {

        $(this).parent().remove();
    }));
    

    $("#FilterDataSearch").on("click", (function () {
        var Type = $("#SelectedFilter").val() != undefined ? $("#SelectedFilter").val() : "0"; ;
        var Query = $("#StudentSearch").val() != undefined ? $("#StudentSearch").val() : "";
        StudentTableInitialize({ FilterType: Type, FilterQuery: Query });
        //GetAllStudentsData({ FilterType: Type, FilterQuery:Query });
    }));


    $("#CSubjectBlock").on("click", ".RemoveSubjectButton", (function () {

        $(this).parent().remove();
    }));

    $("#AddSubjectButton").on("click", (function () {

        AddSubject("SubjectBlock");
    }));

    $("#CreateNewStudentModalButton").on("click", function () {

        $("#CSubjectBlock").html("");
        $("#CAddSubjectButton").trigger("click");

    });
    


    $("#CAddSubjectButton").on("click", (function () {

        AddSubject("CSubjectBlock");
    }));

    $("#CSubjectBlock").on("blur", ".StudentMarks", function () {
        if (parseInt($(this).val()) > 100) {
            $(this).val("100");
        }
        else if ($(this).val().trim() == "" ) {
            $(this).val("0");
        }
    });
    $("#SubjectBlock").on("blur", ".StudentMarks", function () {
        if (parseInt($(this).val()) > 100) {
            $(this).val("100");
        }
        else if ($(this).val().trim() == "") {
            $(this).val("0");
        }
    });


    
    $("#StudentDataTableBody").on("click", "[data-target='#editStudentData']", function () {
        var StudentDataObject = $(this).parent().parent().data();

        PlaceRowDataInUpdateBox(StudentDataObject);

    });


    $("#StudentDataTable").on("click", "[data-target='#deleteStudentData']", function () {

        DeleteStudentID = $(this).parent().parent().data().StudentId;

    });

    $("#DeleteStudent").on("click", function () {
        if (DeleteStudentID != "" && DeleteStudentID != "0") {
            DeleteStudentsData(DeleteStudentID);
        }

    });



    $("#CreateStudentButton").on("click", function () {
        if (CStudentDetailValidation()) {

            CreateStudentInfo(CreateStudentDetailsData());

        } else {
            alert("data is not properly filled");
        }
    });



    
    $("#UpdateStudentButton").on("click", function () {
        if (UStudentDetailValidation()) {

            UpdateStudentInfo(GetStudentDetailsData());

        } else {
            alert("data is not properly filled");
        }

    });

});