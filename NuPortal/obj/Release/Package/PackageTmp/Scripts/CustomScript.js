﻿var buttonClick = -1;
var divid = 4;
var expFileNum = 0;
var checkboxNum = 1;
var months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
function nextclick() {
    if (buttonClick != 5) {
        buttonClick = buttonClick + 1;
        ShowDivs();
    }
}

function prevclick() {
    if (buttonClick != 0) {
        buttonClick = buttonClick - 1;
        ShowDivs();
    }
}

function LoadPage() {
    buttonClick = 0;
    ShowDivs();
}

function ShowDivs() {
    for (var i = 0; i <= 5; i++)
        $(".divEmp" + i).hide();
    $(".divEmp" + buttonClick).show();
}

//Add row in table / clone a row
function addRow(obj, labelObj) {
    if (labelObj != null)
        labelObj.text("");
    var $table = $(obj).closest('table');
    if ($table.find("#ui-datepicker-div").length > 0)
        $table.find("#ui-datepicker-div").remove();
    var $tr = $table.find("tr:eq(0)").clone();
    var $lastTrId = $table.find("tbody:first > tr:last").attr("id").split("tr");
    divid = divid + 1;
    var trID = "tr" + (divid);
    $tr.attr("id", trID);
    $table.append($tr);
    ClearAllControlValues(trID);
    sliding();
    if (buttonClick != -1) {
        DefineFileUploads();
        DefineIdentityFileUploads();
    }
    dateCheck();
    $('.identity').click();
    DefineDP();
}

function DefineDP() {
    $('body').on('focus', ".sdateExp", function () {
        $(this).removeAttr('id').removeClass('hasDatepicker');
        $(this).datepicker({
            dateFormat: 'mm/dd/yy',
            beforeShow: function (textbox, instance) {
                $(this).closest('div').append($('#ui-datepicker-div'));
            },
            changeMonth: true,
            changeYear: true,
            yearRange: '1900:2100'
        });
    });
    $('body').on('focus', ".edateExp", function () {
        $(this).removeAttr('id').removeClass('hasDatepicker');
        $(this).datepicker({
            dateFormat: 'mm/dd/yy',
            beforeShow: function (textbox, instance) {
                $(this).closest('div').append($('#ui-datepicker-div'));
            },
            changeMonth: true,
            changeYear: true,
            yearRange: '1900:2100'
        });
    });
    $('body').on('focus', ".visadateText", function () {
        $(this).removeAttr('id').removeClass('hasDatepicker');
        $(this).datepicker({
            dateFormat: 'mm/dd/yy',
            beforeShow: function (textbox, instance) {
                $(this).closest('div').append($('#ui-datepicker-div'));
            },
            changeMonth: true,
            changeYear: true,
            yearRange: '1900:2100'
        });
    });
}
//To make ddl label floated in load function
function SimulateDdlClicks() {
    $('#ddlTitle').click();
    $('#ddlDesignation').click();
    $('#ddlEmptType').click();
    $('#ddlLocation').click();
    $('.identity').click();
    $('#ddlEmpstatus').click();
}

//Declare slider in academic user info
function sliding() {
    $(".sliders").each(function () {
        $(this).find('.percentageslider').slider({
            animate: true,
            range: "min",
            value: parseInt($(this).parent().find('.lblPercentage')[0].innerText),
            min: 0,
            max: 100,
            step: 1,
            slide: function (event, ui) {
                $(this).parent().find('.lblPercentage')[0].innerText = ui.value;
            }
        });
    });
}

//Delete current row in table
function deleteRow(obj, labelObj) {
    labelObj.text("");
    var len = $(obj).closest("table").find("tbody > tr").length;
    if (len > 1) {
        obj.closest('tr').remove();
    }
}

//Clear all controls
function ClearAllControlValues(divID) {
    var searchElms = document.getElementById(divID).getElementsByTagName("*");
    for (i = 0; i < searchElms.length; i++) {
        var elmt = searchElms[i];
        var type = searchElms[i].type;
        var tag = searchElms[i].tagName.toLowerCase(); // normalize case

        // to reset the value attr of text inputs,
        // password inputs, fileUpload and textareas
        if (type == 'text' || type == 'password' || type == 'textarea' || tag == 'textarea' || type == 'file' || type == "hidden")
            elmt.value = "";
            // checkboxes and radios need to have their checked state cleared                
        else if (type == 'checkbox' || type == 'radio')
            elmt.checked = false;
            //single select elements need to have their 'selectedIndex' property set to -1               
        else if (type == 'select-one') {
            //elmt.options[0].selected = true;
            $(elmt).attr("value", "");

        }
            //multi select elements need to have their selection clear
        else if (type == 'select-multiple') {
            while (elmt.selectedIndex != -1) {
                indx = elmt.selectedIndex;
                elmt.options[indx].selected = false;
            }
            elmt.selected = false;
        }
            //else if (tag == "span" && (elmt.className != "ms-inputuserfield" && elmt.className != "rightpeoplepickertextbox") && elmt.className != "required")
            //    elmt.innerText = "";
        else if (tag == "label" && elmt.className == 'lblPercentage')
            elmt.innerText = "0";
        ;
        if (elmt.classList.contains("ui-slider-range") && elmt.classList.contains("ui-widget-header"))
            elmt.classList.remove("ui-widget-header");
        // to reset the value of sharepoint people picker 
        if (elmt.classList.contains("docDiv") || elmt.classList.contains("competancylist") || elmt.id.indexOf("_upLevelDiv") != -1)
            $(elmt).html('');
        if (elmt.id.indexOf("lblNoOfDays") != -1)
            elmt.innerText = "0";
        if (elmt.classList.contains("divdocuments"))
            $(elmt).hide();
        //if (elmt.classList.contains("IdentityType"))
        //    ("GetDdlIdentity", $(elmt), "IdentityTypeId", "IdentityType");
    }

    $(".htmTable").find("tbody > tr:gt(0)").remove();
    $("#" + divID).find(".ErrorFocus").each(function () {

        $(this).removeClass("ErrorFocus");

    });
    $("#" + divID).find(".clientinfologo").each(function () {


        $(this).empty();
    });
    $("#" + divID).find(".lblError").each(function () {

        $(this).text("");
        $(this).removeClass("ErrorFocus");

    });
    $("#" + divID).find(".lblMessage").each(function () {

        $(this).text("");
        $(this).removeClass("ErrorFocus");

    });
    return false;
}

//show success alerts after saving based on returned json
function ShowAlert(data, message) {
    var returnval = $.parseJSON(data);
    if (returnval["Result"] == "Success")
        alert(message + " Updated Successfully");
    //else
    //    alert("Error in " + message + " updation!");
}

function ShowLabelMessage(data, message, lblObject) {
    var returnval = $.parseJSON(data);
    if (returnval["Result"] == "Success") {
        lblObject.removeClass("lblError");
        lblObject.addClass("lblMessage");
        lblObject.text(message + " Updated Successfully");
    }
    //else
    //    alert("Error in " + message + " updation!");
}

//Validations in admin - user page
function Validate(type) {
    var returnVal = true; var returnNumeric = true;
    if (type == "Emp") {
        if ($("#txtFname").val() == "") {
            $("#txtFname").addClass("ErrorFocus");
            $("#txtFname").focus();
            returnVal = false;
        }
        else
            $("#txtFname").removeClass("ErrorFocus");

        if ($("#txtEmpCode").val() == "") {
            $("#txtEmpCode").addClass("ErrorFocus");
            $("#txtEmpCode").focus();
            returnVal = false;
        }
        else
            $("#txtEmpCode").removeClass("ErrorFocus");

        if ($("#txtOfficeEmail").val() == "") {
            $("#txtOfficeEmail").addClass("ErrorFocus");
            $("#txtOfficeEmail").focus();
            returnVal = false;
        }
        else
            $("#txtOfficeEmail").removeClass("ErrorFocus");

        //if ($("#txtOfficeEmail").val().length > 0) {

        //    var email = document.getElementById("txtOfficeEmail");
        //    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        //    if (!filter.test(email.value)) {
        //        alert('Please provide a valid email address');
        //        email.focus;
        //        return false;
        //    }
        //}
        if ($("#txtJoinDate").val() == "") {
            $("#txtJoinDate").addClass("ErrorFocus");
            $("#txtJoinDate").focus();
            returnVal = false;
        }
        else
            $("#txtJoinDate").removeClass("ErrorFocus");
        if ($("#txtJoinDate").val() == "") {
            $("#txtJoinDate").addClass("ErrorFocus");
            $("#txtJoinDate").focus();
            returnVal = false;
        }
        else
            $("#txtJoinDate").removeClass("ErrorFocus");

        if ($("#ddlDesignation option:selected").text() == "") {
            $("#ddlDesignation").addClass("ErrorFocus");
            //$("#ddlDesignation").focus();
            returnVal = false;
        }
        else
            $("#ddlDesignation").removeClass("ErrorFocus");

        if ($("#ddlLocation option:selected").text() == "") {
            $("#ddlLocation").addClass("ErrorFocus");
            //$("#ddlLocation").focus();
            returnVal = false;
        }
        else
            $("#ddlLocation").removeClass("ErrorFocus");

        if ($("#txtManager").val() == "") {
            $("#txtManager").addClass("ErrorFocus");
            $("#txtManager").focus();
            returnVal = false;
        }
        else
            $("#txtManager").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblEmpError").addClass("lblError");
            $("#lblEmpError").removeClass("lblMessage");
            $("#lblEmpError").text("Please fill all mandatory fields");
        } else {
            $("#lblEmpError").text('');
            $("#lblEmpError").removeClass("lblError");
            $("#lblEmpError").addClass("lblMessage");
        }
    }
    else if (type == "Personal") {
        if ($("#txtaddress1").val() == "") {
            $("#txtaddress1").addClass("ErrorFocus");
            $("#txtaddress1").focus();
            returnVal = false;
        }
        else
            $("#txtaddress1").removeClass("ErrorFocus");

        if ($("#txtphone1").val() == "") {
            $("#txtphone1").addClass("ErrorFocus");
            $("#txtphone1").focus();
            returnVal = false;
        }
        else
            $("#txtphone1").removeClass("ErrorFocus");

        if ($("#txtzipcode1").val() == "") {
            $("#txtzipcode1").addClass("ErrorFocus");
            $("#txtzipcode1").focus();
            returnVal = false;
        }
        else
            $("#txtzipcode1").removeClass("ErrorFocus");

        if ($("#txtEmail").val() == "") {
            $("#txtEmail").addClass("ErrorFocus");
            $("#txtEmail").focus();
            returnVal = false;
        }
        else
            $("#txtEmail").removeClass("ErrorFocus");
        //if ($("#txtEmail").val().length > 0) {

        //    var email = document.getElementById("txtEmail");
        //    var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

        //    if (!filter.test(email.value)) {
        //        alert('Please provide a valid email address');
        //        email.focus;
        //        return false;
        //    }
        //}

        if ($("#txtDob").val() == "") {
            $("#txtDob").addClass("ErrorFocus");
            $("#txtDob").focus();
            returnVal = false;
        }
        else
            $("#txtDob").removeClass("ErrorFocus");

        if (!returnVal) {
            $("#lblPersonalError").addClass("lblError");
            $("#lblPersonalError").removeClass("lblMessage");
            $("#lblPersonalError").text("Please fill all mandatory fields");
        } else {
            $("#lblPersonalError").text('');
            $("#lblPersonalError").removeClass("lblError");
            $("#lblPersonalError").addClass("lblMessage");
        }
    }

        //Admin page
    else if (type == "EmpAdm") {
        //var returnVal = true;
        if ($("#txtFname").val() == "") {
            $("#txtFname").addClass("ErrorFocus");
            $("#txtFname").focus();
            returnVal = false;
        }
        else
            $("#txtFname").removeClass("ErrorFocus");

        if ($("#txtEmpCode").val() == "") {
            $("#txtEmpCode").addClass("ErrorFocus");
            $("#txtEmpCode").focus();
            returnVal = false;
        }
        else
            $("#txtEmpCode").removeClass("ErrorFocus");

        if ($("#txtOfficeEmail").val() == "") {
            $("#txtOfficeEmail").addClass("ErrorFocus");
            $("#txtOfficeEmail").focus();
            returnVal = false;
        }
        else
            $("#txtOfficeEmail").removeClass("ErrorFocus");
        if ($("#txtOfficeEmail").val().length > 0) {

            var email = document.getElementById("txtOfficeEmail");
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;

            if (!filter.test(email.value)) {
                alert('Please provide a valid email address');
                $("#txtOfficeEmail").removeClass("ErrorFocus");
                email.focus;
                return false;
            }
        }
        if ($("#txtJoinDate").val() == "") {

            $("#txtJoinDate").addClass("ErrorFocus");
            $("#txtJoinDate").focus();
            returnVal = false;
        }
        else
            $("#txtJoinDate").removeClass("ErrorFocus");

        if ($("#ddlDesignation option:selected").text() == "") {
            $("#ddlDesignation").addClass("ErrorFocus");
            //$("#ddlDesignation").focus();
            returnVal = false;
        }
        else
            $("#ddlDesignation").removeClass("ErrorFocus");

        if ($("#ddlLocation option:selected").text() == "") {
            $("#ddlLocation").addClass("ErrorFocus");
            //$("#ddlLocation").focus();
            returnVal = false;
        }
        else
            $("#ddlLocation").removeClass("ErrorFocus");

        if ($("#txtManager").val() == "") {
            $("#txtManager").addClass("ErrorFocus");
            $("#txtManager").focus();
            returnVal = false;
        }
        else
            $("#txtManager").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblAdminEmpMsg").addClass('lblError');
            $("#lblAdminEmpMsg").removeClass('lblMessage');
            $("#lblAdminEmpMsg").text("Please fill all mandatory fields");
        }
        else {
            $("#lblAdminEmpMsg").text("");
            $("#lblAdminEmpMsg").removeClass('lblError');
            $("#lblAdminEmpMsg").addClass('lblMessage');
        }
    }
    else if (type == "RequestForm") {
        var selectedRequestType = $("#ddlRequestType").val()
        if (selectedRequestType == 6 || selectedRequestType == 7) {
            if ($("#dtReqDate").val().replace(/\s*$/, "") == "") {
                $("#dtReqDate").addClass("ErrorFocus");
                $("#dtReqDate").focus();
                returnVal = false;
            }
        } else $("#dtReqDate").removeClass("ErrorFocus");
        if ($("#ddlRequestType").prop('selectedIndex') == 0) {
            returnVal = false;
            $("#ddlRequestType").addClass("ErrorFocus");
        } else $("#ddlRequestType").removeClass("ErrorFocus");
        //if (!returnVal) {
        //    $("#lblNewRquestError").text("Please fill all mandatory fields");
        //} else $("#lblNewAllowanceError").text('');
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
    }
    else if (type == "AllowanceForm") {

        if ($("#dtAllowanceDate").val().replace(/\s*$/, "") == "") {
            $("#dtAllowanceDate").addClass("ErrorFocus");
            //$("#dtAllowanceDate").focus();
            returnVal = false;
        }
        else $("#dtAllowanceDate").removeClass("ErrorFocus");
        if ($("#nuAmount").val().replace(/\s*$/, "") == "") {
            $("#nuAmount").addClass("ErrorFocus");
            //$("#nuAmount").focus();
            returnVal = false;
        }
        else $("#nuAmount").removeClass("ErrorFocus");
        //if ($("#txtAllowanceDesc").val().replace(/\s*$/, "") == "") {
        //    $("#txtAllowanceDesc").addClass("ErrorFocus");
        //    //$("#txtAllowanceDesc").focus();
        //    returnVal = false;
        //}
        //else $("#txtAllowanceDesc").removeClass("ErrorFocus");
        if ($("#ddlAllowanceType").prop('selectedIndex') == 0) {
            returnVal = false;
            $("#ddlAllowanceType").addClass("ErrorFocus");
        } else $("#ddlAllowanceType").removeClass("ErrorFocus");

        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
    }
    else if (type == "ReimForm") {

        if ($("#txtStartDate").val().replace(/\s*$/, "") == "") {
            $("#txtStartDate").addClass("ErrorFocus");
            //$("#dtAllowanceDate").focus();
            returnVal = false;
        }
        else $("#txtStartDate").removeClass("ErrorFocus");
        if ($("#txtEndDate").val().replace(/\s*$/, "") == "") {
            $("#txtEndDate").addClass("ErrorFocus");
            //$("#dtAllowanceDate").focus();
            returnVal = false;
        }
        else $("#txtEndDate").removeClass("ErrorFocus");
        if ($("#txtAmount").val().replace(/\s*$/, "") == "") {
            $("#txtAmount").addClass("ErrorFocus");
            //$("#nuAmount").focus();
            returnVal = false;
        }
        else $("#txtAmount").removeClass("ErrorFocus");
        //if ($("#txtAllowanceDesc").val().replace(/\s*$/, "") == "") {
        //    $("#txtAllowanceDesc").addClass("ErrorFocus");
        //    //$("#txtAllowanceDesc").focus();
        //    returnVal = false;
        //}
        //else $("#txtAllowanceDesc").removeClass("ErrorFocus");
        if ($("#ddlReimbType").prop('selectedIndex') == 0) {
            returnVal = false;
            $("#ddlReimbType").addClass("ErrorFocus");
        } else $("#ddlReimbType").removeClass("ErrorFocus");

        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
    }
    else if (type == "newtask") {
        if ($("#txtTaskName").val() == "") {
            $("#txtTaskName").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtTaskName").removeClass("ErrorFocus");

        if ($("#txtPlannedHours").val() == "") {
            $("#txtPlannedHours").addClass("ErrorFocus");
            returnVal = false;
        }

        if ($("#txtPlannedHours").val().length > 0) {

            var inputvalue = document.getElementById("txtPlannedHours");
            var filter = /^[0-9]*$/;

            if (!filter.test(inputvalue.value)) {
                $("#txtPlannedHours").addClass("ErrorFocus");
                returnNumeric = false;
            }
            else if (filter.test(inputvalue.value)) {
                $("#txtPlannedHours").removeClass("ErrorFocus");
            }
        }
        if ($("#ddlTaskStatus option:selected").text() == "") {
            $("#ddlTaskStatus").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#ddlTaskStatus").removeClass("ErrorFocus");

        if ($("#listResources").is(':empty')) {
            $("#divResources").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#divResources").removeClass("ErrorFocus");
        //if ($("#txtStartDate").val() == "") {
        //    $("#txtStartDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#txtStartDate").removeClass("ErrorFocus");

        //if ($("#txtEndDate").val() == "") {
        //    $("#txtEndDate").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#txtEndDate").removeClass("ErrorFocus");

        //if ($("#txtPlannedHours").val() == "") {
        //    $("#txtPlannedHours").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#txtPlannedHours").removeClass("ErrorFocus");

        //if ($("#txtTaskDetails").val() == "") {
        //    $("#txtTaskDetails").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#txtTaskDetails").removeClass("ErrorFocus");

        //if ($("#txtComments").val() == "") {
        //    $("#txtComments").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#txtComments").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        }
        else if (returnVal && !returnNumeric) {

            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please provide a valid Numeric value");

        }
        else if (returnVal) {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
    }
    else if (type == "status") {
        //if ($("#txtComments").val() == "") {
        //    $("#txtComments").addClass("ErrorFocus");
        //    returnVal = false;
        //}
        //else
        //    $("#txtComments").removeClass("ErrorFocus");
        if ($("#ddlTaskStatus").prop('selectedIndex') == 0) {
            returnVal = false;
            $("#ddlTaskStatus").addClass("ErrorFocus");
        } else $("#ddlTaskStatus").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblNewTaskError").text("Please fill all mandatory fields");
        } else $("#lblNewTaskError").text('');
    }
    else if (type == "newcontacts") {
        if ($("#txtpopClient").val() == "") {
            $("#txtpopClient").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtpopClient").removeClass("ErrorFocus");
        if ($("#txtContactPerson").val() == "") {
            $("#txtContactPerson").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtContactPerson").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblErrorMsg").text("Please fill all mandatory fields");
        } else $("#lblErrorMsg").text('');
    }
    else if (type == "LeaveForm") {
        if ($("#dtStartDate").val() == "") {
            $("#dtStartDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#dtStartDate").removeClass("ErrorFocus");

        if ($("#dtEndDate").val() == "") {
            $("#dtEndDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#dtEndDate").removeClass("ErrorFocus");

        if ($("#txtLeaveDesc").val() == "") {
            $("#txtLeaveDesc").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtLeaveDesc").removeClass("ErrorFocus");

        if ($("#ddlLeaveType option:selected").text() == "") {
            $("#ddlLeaveType").addClass("ErrorFocus");
            //$("#ddlDesignation").focus();
            returnVal = false;
        }
        else
            $("#ddlLeaveType").removeClass("ErrorFocus");

        if ($("#dtStartDate").val() != "" && $("#dtEndDate").val() != "") {
            var arrDate1 = $('#dtStartDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#dtEndDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $("#lblNewLeaveError").text("The End Date must be greater than the Start Date");
                returnVal = false;
            } else $("#lblNewLeaveError").text('');
        }

        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
    }
        //TimeSheet Validation
    else if (type == "TimeSheet") {
        $("#txtStartDate").removeClass("ErrorFocus");
        $("#txtEndDate").removeClass("ErrorFocus");
        if ($("#listResources").is(':empty')) {
            $("#divResources").addClass("ErrorFocus");
            returnVal = false;
            $("#lblTsError").text("Please fill all mandatory fields");
        }
        else
            $("#divResources").removeClass("ErrorFocus");
        if ($("#txtStartDate").val() != "" && $("#txtEndDate").val() != "") {
            if (!CompareDates($("#txtStartDate").val(), $("#txtEndDate").val())) {
                returnVal = false;
                $("#txtStartDate").addClass("ErrorFocus");
                $("#txtEndDate").addClass("ErrorFocus");
                $("#lblTsError").text("StartDate must be less than end date");
            }
            else {
                $("#txtStartDate").removeClass("ErrorFocus");
                $("#txtEndDate").removeClass("ErrorFocus");
            }
        }
        if (returnVal) {
            $("#lblTsError").text('');
        }
    }
        //TimeSheet calender select
    else if (type == "TimeSheetSelect") {
        if ($("#ddlReportType option:selected").text() == "") {
            $("#ddlReportType").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#ddlReportType").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblTsSelectError").text("Please select a type");
        } else $("#lblTsSelectError").text('');
    }
    else if (type == "NewClient") {
        if ($("#txtCompanyName").val() == "") {
            $("#txtCompanyName").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtCompanyName").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
    }


    else if (type == "AddEvents") {
        if ($("#txtTitle").val() == "") {
            $("#txtTitle").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtTitle").removeClass("ErrorFocus");
        if ($("#txtStartDate").val() == "") {
            $("#txtStartDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtStartDate").removeClass("ErrorFocus");
        if ($("#txtEndDate").val() == "") {
            $("#txtEndDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtEndDate").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
        if ($("#txtStartDate").val() != "" && $("#txtEndDate").val() != "") {
            var arrDate1 = $('#txtStartDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#txtEndDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $("#lblMessage").removeClass("lblMessage");
                $("#lblMessage").addClass("lblError");
                $("#lblMessage").text("The End Date must be greater than the Start Date");
                returnVal = false;
            } else $("#lblMessage").text('');
        }
    }
        //Add announcement validation
    else if (type == "addannouncement") {
        if ($("#txtTitle").val() == "") {
            $("#txtTitle").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtTitle").removeClass("ErrorFocus");
        if ($("#txtStartDate").val() == "") {
            $("#txtStartDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtStartDate").removeClass("ErrorFocus");
        if ($("#txtEndDate").val() == "") {
            $("#txtEndDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtEndDate").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
        if ($("#txtStartDate").val() != "" && $("#txtEndDate").val() != "") {
            var arrDate1 = $('#txtStartDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#txtEndDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $("#lblMessage").text("The End Date must be greater than the Start Date");
                returnVal = false;
            } else $("#lblMessage").text('');
        }
    }
    else if (type == "AddDocument") {
        if ($("#txtDocumentName").val() == "") {
            $("#txtDocumentName").addClass("ErrorFocus");
            $("#lblMessage").text("Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#txtDocumentName").removeClass("ErrorFocus");
        $("#lblMessage").text("");

        if ($("#ddlProjectName").val() == "") {
            $("#ddlProjectName").addClass("ErrorFocus");
            $("#lblMessage").text("Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#ddlProjectName").removeClass("ErrorFocus");
        $("#lblMessage").text("");
        if ($("#ddlSharedWith").val() == "") {
            $("#ddlSharedWith").addClass("ErrorFocus");
            $("#lblMessage").text("Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#ddlSharedWith").removeClass("ErrorFocus");
        $("#lblMessage").text("");

        if ($("#filehidden").val() == "") {
            $("#fileUploadAttachment").addClass("ErrorFocus");
            $("#lblMessage").text("Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#fileUploadAttachment").removeClass("ErrorFocus");
        $("#lblMessage").text("");
    }
        //validate rate other employee page
    else if (type == "rateotheremployee") {
        if ($("#listResources").is(':empty')) {
            $("#divResources").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#divResources").removeClass("ErrorFocus");
        if ($("#ddlRatingFactor").val() == "") {
            $("#ddlRatingFactor").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#ddlRatingFactor").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
        //if ($("#fldratings").val() == "") {
        //    $("#fldratings").addClass("ErrorFocus");
        //    $("#lblMessage").text("Please fill all mandatory fields");
        //    returnVal = false;
        //}
        //else
        //        $("#fldratings").removeClass("ErrorFocus");
    }
        //Validate newDocument
    else if (type == "NewDocument") {
        if ($("#txtDocName").val() == "") {
            $("#txtDocName").addClass("ErrorFocus");
            $("#lblMessage").text("Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#txtDocName").removeClass("ErrorFocus");
        $("#lblMessage").text("");

        if ($("#ddlShareWith").val() == "") {
            $("#ddlShareWith").addClass("ErrorFocus");
            $("#lblMessage").text("Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#ddlShareWith").removeClass("ErrorFocus");
        $("#lblMessage").text("");

        if ($("#filehidden").val() == "") {
            $("#fileUploadAttachment").addClass("ErrorFocus");
            $("#lblMessage").text("Please fill all mandatory fields");
            returnVal = false;
        }
        else
            $("#fileUploadAttachment").removeClass("ErrorFocus");
        $("#lblMessage").text("");
    }

    else if (type == "NewTraining") {
        var type = 0;
        if (($("#listResources").find(".divcompetancy").attr("name")) == undefined) {
            $("#divResources").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#divResources").removeClass("ErrorFocus");
        if ($("#txtSubject").val() == "") {
            $("#txtSubject").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtSubject").removeClass("ErrorFocus");
        if ($("#txtTrainer").val() == "") {
            $("#txtTrainer").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtTrainer").removeClass("ErrorFocus");
        if ($("#txtFromDate").val() == "") {
            $("#txtFromDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtFromDate").removeClass("ErrorFocus");
        if ($("#txtToDate").val() == "") {
            $("#txtToDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtToDate").removeClass("ErrorFocus");
        if ($("#txtFromDate").val() != "" && $("#txtToDate").val() != "") {
            var arrDate1 = $('#txtFromDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#txtToDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                type = 1;
                $("#lblMessage").removeClass("lblMessage");
                $("#lblMessage").addClass("lblError");
                $("#lblMessage").text("The End Date must be greater than the Start Date");
                returnVal = false;
            }
            else {
                type = 0;
                $("#lblMessage").text('');
            }
        }
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            if (type == 0)
                $("#lblMessage").text("Please fill all mandatory fields");
            else if (type == 1)
                $("#lblMessage").text("The End Date must be greater than the Start Date");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }

    }

    else if (type == "updateTraining") {
        var type = 0;
        if ($("#txtSubject").val() == "") {
            $("#txtSubject").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtSubject").removeClass("ErrorFocus");
        if (($("#listResources").find(".divcompetancy").attr("name") == "") || ($("#listResources").find(".divcompetancy").attr("name") == undefined)) {
            $("#divManager").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#divManager").removeClass("ErrorFocus");
        if ($("#txtFrom").val() == "") {
            $("#txtFrom").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtFrom").removeClass("ErrorFocus");
        if ($("#txtTo").val() == "") {
            $("#txtTo").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtTo").removeClass("ErrorFocus");
        if ($("#txtFrom").val() != "" && $("#txtTo").val() != "") {
            var arrDate1 = $('#txtFrom').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#txtTo').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                type = 1;
                $("#lblMessage").removeClass("lblMessage");
                $("#lblMessage").addClass("lblError");
                $("#lblMessage").text("The End Date must be greater than the Start Date");
                returnVal = false;
            }
            else {
                type = 0;
                $("#lblMessage").text('');
            }
        }
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            if (type == 0)
                $("#lblMessage").text("Please fill all mandatory fields");
            else if (type == 1)
                $("#lblMessage").text("The End Date must be greater than the Start Date");
        }
        else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }

    }


    else if (type == "exitdoc") {
        if (($("#listResources").find(".divcompetancy").attr("name") == "") || ($("#listResources").find(".divcompetancy").attr("name") == undefined)) {
            $("#divResources").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#divResources").removeClass("ErrorFocus");
        if ($("#txtReleivingDate").val() == "") {
            $("#txtReleivingDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtReleivingDate").removeClass("ErrorFocus");
        if (($("#filehidden").val() == "") && ($("#Attachment").val() == "")) {
            $("#fileUploadAttachment").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#fileUploadAttachment").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");
        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }
    }

    else if (type == "OfficePoll") {

        if ($("#txtTitle").val() == "") {
            $("#txtTitle").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtTitle").removeClass("ErrorFocus");
        if ($("#txtEndDate").val() == "") {
            $("#txtEndDate").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtEndDate").removeClass("ErrorFocus");
        if ($("#txtTopic").val() == "") {
            $("#txtTopic").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#txtTopic").removeClass("ErrorFocus");
        if ($("#ddlFieldType option:selected").text() == "") {
            $("#ddlFieldType").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#ddlFieldType").removeClass("ErrorFocus");
        if (($("#ddlFieldType option:selected").text() != "TextBox") && ($(".divcompetancy").text() == "")) {
            $(".contenttextarea").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $(".contenttextarea").removeClass("ErrorFocus");
        if (!returnVal) {
            $("#lblMessage").addClass("lblError");
            $("#lblMessage").removeClass("lblMessage");
            $("#lblMessage").text("Please fill all mandatory fields");

        } else {
            $("#lblMessage").text('');
            $("#lblMessage").removeClass("lblError");
            $("#lblMessage").addClass("lblMessage");
        }

    }
    return returnVal;

}



//formatDate to required format
function FormatDate(dateVal, format) {
    if (dateVal != null && dateVal != "") {
        var dobDate;
        if (format == "mm/dd/yyyy" && dateVal.indexOf("/Date(") >= 0) {
            dobDate = new Date(parseInt(dateVal.substr(6)));
        }
        else
            dobDate = new Date(dateVal);
        var d = dobDate.getDate();
        var y = dobDate.getFullYear();
        if (d < 10)
            d = "0" + d;
        var m = dobDate.getMonth() + 1;
        if (m < 10)
            m = "0" + m;
        if (format == "mm/dd/yyyy")
            return m + "/" + d + "/" + y;
        else if (format == "dd/mm/yyyy")
            return d + "/" + m + "/" + y;
        else if (format == "yyyy/mm/dd")
            return y + "/" + m + "/" + d;
    }
    else
        return "01/01/1753";
    return "";
}


//To check if date is in mm/dd/yyyy format
function dateCheck() {
    //$(".dateText").focusout(function () {
    //    if ($(this).val() != "") {
    //        var errorMsg = "Enter Valid Date (MM/DD/YYYY)";
    //        var reGoodDate = /^((0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01])[- /.](19|20)?[0-9]{2})*$/;
    //        if (!reGoodDate.test($(this).val())) {
    //            $(this).addClass("ErrorFocus");
    //            $(this).focus();
    //            if (buttonClick == 0) {
    //                $("#lblEmpError").text(errorMsg);
    //            }
    //            else if (buttonClick == 4) {
    //                $("#lblExpError").text(errorMsg);
    //            }
    //            else if (buttonClick == 5) {
    //                $("#lblIdentError").text(errorMsg);
    //            }
    //            else if (buttonClick == 1) {
    //                $("#lblPersonalError").text(errorMsg);
    //            }
    //            else {
    //                $("#lblNewAllowanceError").text(errorMsg);
    //            }
    //            return false;
    //        }
    //        else
    //            $(this).removeClass("ErrorFocus");
    //    }
    //    $("#lblNewAllowanceError").text('');
    //    $("#lblEmpError").text('');
    //    $("#lblExpError").text('');
    //    $("#lblIdentError").text('');
    //    //$(this).removeClass("ErrorFocus");
    //});
}

function getCurrentDiv() {
    return buttonClick;
}
//Displaying image at the time of file upload.
function readURL(input, objectImage) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            objectImage.attr('src', e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function LoadDdls(pathUrl, ddlObject, KeyField, ValueField) {
    $.ajax({
        url: pathUrl,
        type: "GET",
        async: false,
        success: function (result) {
            var resultVals = $.parseJSON(result);
            if (resultVals["Error"] == undefined || resultVals["Error"] == null) {
                for (var i = 0; i < resultVals.length; i++) {
                    ddlObject.append('<option value=' + resultVals[i][KeyField] + '>' + resultVals[i][ValueField] + '</option>');
                }
            }
        },
        error: function (err) {
            //alert(err.statusText);
        }
    });
}


//Extension check for file upload
function CheckExtension(docElement, filename, accesspath, closebuttondiv, divDocuments, classnumber) {
    var extensionImage = "";
    var fileNameVal = accesspath.split('/').pop();
    var extension = fileNameVal.substr((fileNameVal.lastIndexOf('.') + 1));
    switch (extension) {
        case 'xlsx':
        case 'xlsm':
        case 'xls':
            extensionImage = "../Images/excel.png";
            break;
        case 'doc':
        case 'docx':
        case 'dot':
            extensionImage = "../Images/word.png";
            break;
        case 'pdf':
            extensionImage = "../Images/pdf.jpg";
            break;
        default:
            extensionImage = "../Images/NoImage.jpg";
            break;
    }
    fileNameVal = fileNameVal.indexOf('^_^_^') >= 0 ? fileNameVal.split('^_^_^')[0] + "." + extension : fileNameVal;
    docElement.append("<div id='" + expFileNum + "' class='col-sm-" + classnumber + "'><div class='profilethumbnaildiv'>" +
        closebuttondiv + "<input type='hidden' id='hdnProPicFile' value='" + accesspath + "' class='filehidden' /><a href='" +
        accesspath + "' target='_blank'><img class='profilethumbnaildiv' src='" + extensionImage +
        "' /></a><a href='" + accesspath + "' target='_blank'><div class='profilepictext documentname' title='" +
        fileNameVal + "'>" + fileNameVal + "</div></a></div></div>");
    expFileNum = expFileNum + 1;
    if (divDocuments != null)
        divDocuments.show();
    defineExpUploads();
}

function TrimFileNameDummy(fileUrl) {
    var fileNameVal = fileUrl.split('/').pop();
    var extension = fileNameVal.substr((fileNameVal.lastIndexOf('.') + 1));
    fileNameVal = fileNameVal.indexOf('^_^_^') >= 0 ? fileNameVal.split('^_^_^')[0] + "." + extension : fileNameVal;
    return fileNameVal;
}

function SetSession(Path, jsonString, RedirectPath) {
    $.ajax({
        url: Path,
        type: 'POST',
        dataType: 'json',
        async: true,
        data: {
            jsonData: jsonString
        },
        success: function (data) {
            if (RedirectPath != "")
                window.location.href = RedirectPath;
        },
        error: function (response) {

        },
        failure: function (response) {
            alert(response.responseText);
        }
    });
}

function GetSession(Path, sessionKey) {
    var SessionVal = "";
    $.ajax({
        url: Path,
        type: 'GET',
        async: false,
        dataType: 'json',
        data: {
            SessionKey: sessionKey
        },
        success: function (data) {
            var resultVals = $.parseJSON(data);
            if (resultVals["Error"] == undefined || resultVals["Error"] == null) {
                SessionVal = resultVals[sessionKey];
            }
        },
        error: function (response) {

        },
        failure: function (response) {
            alert(response.responseText);
        }
    });
    return SessionVal;
}

function CompareDates(startDate, endDate) {
    var sDate = new Date(startDate);
    var eDate = new Date(endDate);
    if (sDate > eDate)
        return false;
    else
        return true;
}

function customDateformat(dateStr, format) {
    var date = new Date(dateStr);
    var retStr = format;
    var day = date.getDate(), month = date.getMonth(), year = date.getFullYear(), hr = date.getHours(), min = date.getMinutes(), sec = date.getSeconds();
    if (/d+|D+/.test(format)) {
        if ((format.match(/d+|D+/))[0].length > 1 && day.toString().length < 2) {
            retStr = retStr.replace(/d+|D+/, '0' + day.toString());
        }
        else
            retStr = retStr.replace(/d+|D+/, day);
    }
    if (/M+/.test(format)) {
        if ((format.match(/M+/))[0].length > 1 && (month + 1).toString().length < 2) {
            retStr = retStr.replace(/M+/, '0' + (month + 1).toString());
        }
        else
            retStr = retStr.replace(/M+/, (month + 1));
    }
    if (/y+|Y+/.test(format)) {
        if ((format.match(/y+|Y+/))[0].length > 2) {
            retStr = retStr.replace(/y+|Y+/, year);
        }
        else
            retStr = retStr.replace(/y+|Y+/, year.toString().substring(2, 4));
    }
    if (/h+|H+/.test(format)) {
        if ((format.match(/h+|H+/))[0].length > 1 && hr.toString().length < 2) {
            retStr = retStr.replace(/h+|H+/, '0' + hr.toString());
        }
        else
            retStr = retStr.replace(/h+|H+/, hr);
    }
    if (/m+/.test(format)) {
        if ((format.match(/m+/))[0].length > 1 && min.toString().length < 2) {
            retStr = retStr.replace(/m+/, '0' + min.toString());
        }
        else
            retStr = retStr.replace(/m+/, min);
    }
    if (/s+|S+/.test(format)) {
        if ((format.match(/s+|S+/))[0].length > 1 && sec.toString().length < 2) {
            retStr = retStr.replace(/s+|S+/, '0' + sec.toString());
        }
        else
            retStr = retStr.replace(/s+|S+/, sec);
    }
    return retStr;
}

function DefineDatePicker(txtObject) {
    txtObject.datepicker({
        dateFormat: 'mm/dd/yy',
        beforeShow: function (textbox, instance) {
            $(this).closest('div').append($('#ui-datepicker-div'));
        },
        changeMonth: true,
        changeYear: true,
        yearRange: '1900:2100'
    });
}

function DefineVisaDatePicker(txtObject) {
    txtObject.datepicker({
        dateFormat: 'mm/dd/yy',
        changeMonth: true,
        changeYear: true,
        yearRange: '1900:2100'
    });
}

function DisableHref() {
    $('.leaveacceptbtn').unbind('click');
    $('.hrefClass').css({ "pointer-events": "none" });
}

function EnableHref() { //for confirmation popup in request page
    $('.leaveacceptbtn').bind('click', function () {
        DisableHref();
        saveRequest(0);
    });
    $('.hrefClass').css({ "pointer-events": "all" });
}

function DisableAutoCompleteHref() {
    $('.div2 > div > a').unbind('click');
    $('.div2 > div > a').css({ "pointer-events": "none" });
}

function calendarPrevious(obj) {
    var monthYr = $(obj).parent().find('#monthYeardiv')[0].innerText;
    var mon = months.indexOf(monthYr.split(' ')[0]) + 1;
    var yr = parseInt(monthYr.split(' ')[1]);
    if (mon == 1) {
        yr = parseInt(yr) - 1;
        mon = 13
    }

    getmonthCalendar(yr, mon - 1);
    bindEvents(yr, mon - 1);
}

function calendarNext(obj) {
    var monthYr = $(obj).parent().find('#monthYeardiv')[0].innerText;
    var mon = months.indexOf(monthYr.split(' ')[0]) + 1;
    var yr = parseInt(monthYr.split(' ')[1]);
    if (mon == 12) {
        yr = parseInt(yr) + 1;
        mon = 0
    }

    getmonthCalendar(yr, mon + 1);
    bindEvents(yr, mon + 1);
}

function getmonthCalendar(yr, mon) {
    $('.calendarmainbg').find('tr:gt(0)').remove();
    $('#monthYeardiv')[0].innerText = months[mon - 1] + " " + yr;
    $.ajax({
        url: '/home/GetCalendar',
        dataType: "json",
        type: "GET",
        async: false,
        contentType: 'application/json; charset=utf-8',
        data: { year: yr, month: mon },
        success: function (data) {
            var results = $.parseJSON(data);
            for (var i = 0; i < results.length; i++) {
                $('.calendarmainbg').append('<tr>' +
                        '<td valign="top" name="' + results[i].Sun.split('|')[0] + '" class="calendardate-SUN ' + results[i].Sun.split('|')[1] + '">' + results[i].Sun.split('|')[0] + '</td>' +
                        '<td valign="top" name="' + results[i].Mon.split('|')[0] + '" class="calendardate ' + results[i].Mon.split('|')[1] + '">' + results[i].Mon.split('|')[0] + '</td>' +
                        '<td valign="top" name="' + results[i].Tue.split('|')[0] + '" class="calendardate ' + results[i].Tue.split('|')[1] + '">' + results[i].Tue.split('|')[0] + '</td>' +
                        '<td valign="top" name="' + results[i].Wed.split('|')[0] + '" class="calendardate ' + results[i].Wed.split('|')[1] + '">' + results[i].Wed.split('|')[0] + '</td>' +
                        '<td valign="top" name="' + results[i].Thu.split('|')[0] + '" class="calendardate ' + results[i].Thu.split('|')[1] + '">' + results[i].Thu.split('|')[0] + '</td>' +
                        '<td valign="top" name="' + results[i].Fri.split('|')[0] + '" class="calendardate ' + results[i].Fri.split('|')[1] + '">' + results[i].Fri.split('|')[0] + '</td>' +
                        '<td valign="top" name="' + results[i].Sat.split('|')[0] + '" class="calendardate-SUN ' + results[i].Sat.split('|')[1] + '">' + results[i].Sat.split('|')[0] + '</td>' +
                    '</tr>');
            }
        },
        error: function (xhr) {
        }
    });
}
$(function () {
    $("#divResources").click(function () {
        $("#txtResources").focus();
    });
});

function PreventDefaultClick() {
    $('.div2').find('a').click(function (e) {
        e.preventDefault();
    });
    $('a > .hrefFileClose').click(function (e) {
        e.preventDefault();
    });
    $('.calendareventsMORE > a,.timesheetleftarrow > a,.timesheetrightarrow > a').click(function (e) {
        e.preventDefault();
    });
    $('.closeImage,.visadocumentclosebutton,.hreflink,.popupclosebutton > a,.myprojectenterdiv > a,.feedsassociatebtn > a,.documentlinkdiv > a,.buttondiv>a,.announcementreadmore>a').click(function (e) {
        e.preventDefault();//,.myprojecttxt>a - removed
    });
    $('.PreventDefault > a,.PreventHref').click(function (e) {
        e.preventDefault();
    });
}

function ValidateAllControls(itemCount) {

    for (var i = 1; i <= itemCount; i++) {
        var control = $(".validation" + i);
        if (control != null)
            control.css("border", "");
    }
    for (var i = 1; i <= itemCount; i++) {
        var control = $(".validation" + i);
        if (typeof control[0].type != "undefined" && control[0].type == "select-one" && control.find("option:selected").text() == "") {
            control.focus();
            $('#lblMsg').attr("class", "lblError");
            $('#lblMsg')[0].innerText = "* Please Fill All the fields";
            control.css("border-bottom", "red solid 2px");
            return false;
        }
        else if ((typeof control.attr("type") != "undefined" || typeof control.prop("tagName") != "undefined") && (control.attr("type") == "text" || control.prop("tagName").toLowerCase() == "textarea"
            || control.attr("type") == "file" || control.attr("type") == "password")) {
            if (control.val() == "") {
                control.focus();
                $('#lblMsg').attr("class", "lblError");
                $('#lblMsg')[0].innerText = "* Please Fill All the fields";
                control.css("border-bottom", "red solid 2px");
                return false;
            }
        }
        else if (typeof control.attr("type") != "undefined" && control.attr("type") == "checkbox") {
            if (control.prop("checked") == false) {
                control.focus();
                $('#lblMsg').attr("class", "lblError");
                $('#lblMsg')[0].innerText = "* Please Fill All the fields";
                control.css("border-bottom", "red solid 2px");
                return false;
            }
        }
    }
    $('#lblMsg')[0].innerText = "";
    return true;
}

function onlyNumbers(event) {
    return /[0-9]|Backspace/.test(event.key);
}

function floatNumbers(event) {
    return /[0-9]|Backspace|[.]|Tab/.test(event.key);
}

//validation all controls
function ValidateAll(divID, label) {
    var returnVal = true; var returnMail = true; var startDate, endDate;
    var returnDate = true; var returnEDate = true; var returnRDate = true; var returnDob = true;
    var returnPhNo = true; var returnNumeric = true; var returnFax = true;
    var todayDate = new Date().toDateString();
    var returnStartEnd = true;
    var returnI94 = true;
    var returnEntryExit = true;
    var returnFamilyEntryExit = true;
    //validation for start and end date
    if (divID == "divValidateSave") {
        if ($("#txtPassIssueDate").val() != "" && $("#txtPassValidityDate").val() != "") {
            var arrDate1 = $('#txtPassIssueDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#txtPassValidityDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                
                returnStartEnd = false;

            } else {
                $('#txtPassIssueDate').removeClass("ErrorFocus");
                $('#txtPassValidityDate').removeClass("ErrorFocus");
                returnStartEnd = true;
                $("#" + label).text('');
            }
        }
        if ($("#txtI94IssueDate").val() != "" && $("#txtI94ValidityDate").val() != "") {
            var arrDate1 = $('#txtI94IssueDate').val().split("/");
            var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
            var arrDate2 = $('#txtI94ValidityDate').val().split("/");
            var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
            if (useDate1 > useDate2) {
                $('#txtI94IssueDate').addClass("ErrorFocus");
                $('#txtI94ValidityDate').addClass("ErrorFocus");
                returnI94 = false;
            } else {
                $('#txtI94IssueDate').removeClass("ErrorFocus");
                $('#txtI94ValidityDate').removeClass("ErrorFocus");
                $("#" + label).text('');
                returnI94 = true;

            }
        }
        $("#tblVisaProcess > tbody").children("tr").each(function () {
            if ($(this).find(".EntryDate").val() != "" || $(this).find(".ExitDate").val() != "") {
                var arrDate1 = $(this).find(".EntryDate").val().split("/");
                var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
                var arrDate2 = $(this).find(".ExitDate").val().split("/");
                var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
                if (useDate1 > useDate2) {
                    $(this).find(".EntryDate").addClass("ErrorFocus");
                    $(this).find(".ExitDate").addClass("ErrorFocus");
                    returnEntryExit = false;
                } else {
                    $(this).find(".EntryDate").removeClass("ErrorFocus");
                    $(this).find(".ExitDate").removeClass("ErrorFocus");
                    $("#" + label).text('');
                    returnEntryExit = true;
                }
            }
        });

        $("#tblVisaFamilyDetails > tbody").children("tr").each(function () {
            if ($(this).find(".txtEntry").val() != "" || $(this).find(".txtExit").val() != "") {
                var arrDate1 = $(this).find(".txtEntry").val().split("/");
                var useDate1 = new Date(arrDate1[2], arrDate1[0] - 1, arrDate1[1]);
                var arrDate2 = $(this).find(".txtExit").val().split("/");
                var useDate2 = new Date(arrDate2[2], arrDate2[0] - 1, arrDate2[1]);
                if (useDate1 > useDate2) {
                    $(this).find(".txtEntry").addClass("ErrorFocus");
                    $(this).find(".txtExit").addClass("ErrorFocus");
                    returnFamilyEntryExit = false;
                } else {
                    $(this).find(".txtEntry").removeClass("ErrorFocus");
                    $(this).find(".txtExit").removeClass("ErrorFocus");
                    $("#" + label).text('');
                    returnFamilyEntryExit = true;

                }
            }
        });
    }
    //TextBox
    $("#" + divID).find(".vinput").each(function () {
        if ($(this).val() == "") {
            //$(this).focus();
            $(this).addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $(this).removeClass("ErrorFocus");
    });
    // CheckBox and Radio buttons
    $("#" + divID).find(".vcheckBoxOrRadio").each(function () {
        var checkFields = $("input[name='checkBoxOrRadio']").serializeArray();
        if (checkFields.length === 0) {
            $(this).addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $(this).removeClass("ErrorFocus");
    });
    //Dropdown
    $("#" + divID).find(".vselect").each(function () {
        if ($(this).val() == "" || $(this).val() == "0") {
            //$(this).focus();
            $(this).addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $(this).removeClass("ErrorFocus");
    });
    //managerlist
    $("#" + divID).find(".vmanager").each(function () {

        if ($("#listManager").is(':empty')) {
            $("#divManager").addClass("ErrorFocus");

            returnVal = false;
        }
        else
            $("#divManager").removeClass("ErrorFocus");

    });
    //Assigned Recruiter

    $("#" + divID).find(".vArecruiter").each(function () {

        if ($("#listRecruit").is(':empty')) {
            $("#divRecruit").addClass("ErrorFocus");

            returnVal = false;
        }
        else
            $("#divRecruit").removeClass("ErrorFocus");

    });
    //resource list
    $("#" + divID).find(".vresources").each(function () {

        if ($("#listResources").is(':empty')) {
            $("#divResources").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#divResources").removeClass("ErrorFocus");

    });
    // Interviewer List
    $("#" + divID).find(".vinterviewer").each(function () {

        if ($("#listInterviewer").is(':empty')) {
            $("#divInterviewer").addClass("ErrorFocus");
            returnVal = false;
        }
        else
            $("#divInterviewer").removeClass("ErrorFocus");

    });

    //Email
    $("#" + divID).find(".vemail").each(function () {

        if ($(this).val().length > 0) {
            var filter = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
            if (!filter.test($(this).val())) {

                $(this).addClass("ErrorFocus");
                returnMail = false;
            }
            else if (filter.test($(this).val()))
                $(this).removeClass("ErrorFocus");
        }
    });

    //Date
    $("#" + divID).find(".vdate").each(function () {

        if ($(this).val().length > 0) {

            var filter = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            if (!filter.test($(this).val())) {
                $(this).addClass("ErrorFocus");
                returnDate = false;
            }
            else if (filter.test($(this).val()))
                $(this).removeClass("ErrorFocus");


        }
    });
    //date greater than today
    $("#" + divID).find(".vdateToday").each(function () {

        if ($(this).val().length > 0) {
            var InputDate = new Date($(this).val()).toDateString();

            if ($(this).val() != "" && (Date.parse(todayDate) > Date.parse(InputDate))) {
                $(this).addClass("ErrorFocus");
                returnEDate = false;
            }

        }
    });
    $("#" + divID).find(".vsdate").each(function () {
        if ($(this).val() != "") {
            startDate = new Date($(this).val());
        }

    });

    $("#" + divID).find(".vedate").each(function () {
        if ($(this).val() != "" && (Date.parse(startDate) > Date.parse($(this).val()))) {
            //endDate = new Date($(this).val());          
            $(this).addClass("ErrorFocus");
            returnEDate = false;
        }
        //else if($(this).val() != "" && (Date.parse(startDate) < Date.parse($(this).val())))
        //$(this).removeClass("ErrorFocus");


    });
    $("#" + divID).find(".vrdate").each(function () {
        if ($(this).val() != "" && (Date.parse(startDate) > Date.parse($(this).val()))) {
            //endDate = new Date($(this).val());
            //$(this).focus();
            $(this).addClass("ErrorFocus");
            returnDate = false;
            returnRDate = false;
        }




    });

    //D0B
    $("#" + divID).find(".vdob").each(function () {

        if ($(this).val().length > 0) {
            var filter = /^(\d{1,2})(\/|-)(\d{1,2})(\/|-)(\d{4})$/;
            var minDate = Date.parse("01/01/1900");
            var today = new Date();
            var DOB = Date.parse($(this).val());

            if (!filter.test($(this).val().trim()) || (minDate > DOB || DOB > today)) {
                $(this).addClass("ErrorFocus");
                returnDob = false;
            }
            //else
            // $(this).removeClass("ErrorFocus");
            //compare dob and  current date
        }
    });

    //Phone

    $("#" + divID).find(".vphone").each(function () {

        if ($(this).val().length > 0) {
            //var filter = /^[0-9]{9,15}$/;
            var filter = /^[()0-9 *#+-]+$/;
            if (!filter.test($(this).val().trim())) {
                $(this).addClass("ErrorFocus");
                if (!($(this).hasClass('vfax'))) {
                    returnPhNo = false;

                }

                if (($(this).hasClass('vfax'))) {
                    returnFax = false;

                }
            } else if (filter.test($(this).val().trim()))
                $(this).removeClass("ErrorFocus");

        }
    });

    //Numeric
    $("#" + divID).find(".vnumeric").each(function () {

        if ($(this).val().length > 0) {
            var filter = /^[0-9]*$/;
            if (!filter.test($(this).val().trim())) {
                $(this).addClass("ErrorFocus");
                returnNumeric = false;
            }
            else if (filter.test($(this).val().trim()))
                $(this).removeClass("ErrorFocus");
        }
    });
    //float Numbers
    $("#" + divID).find(".vfloat").each(function () {

        if ($(this).val().length > 0) {
            var filter = /^[0-9]\d*(\.\d+)?$/;
            if (!filter.test($(this).val().trim())) {
                $(this).addClass("ErrorFocus");
                returnNumeric = false;
            }
            else if (filter.test($(this).val().trim()))
                $(this).removeClass("ErrorFocus");
        }
    });

    //label-Error messages 

    if (!returnStartEnd) {
        $('#txtPassIssueDate').addClass("ErrorFocus");
        $('#txtPassValidityDate').addClass("ErrorFocus");
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("The Passport Validity Date must be greater than Issue Date");
        return false;
    }
    else if (!returnI94) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("The I-94 Validity Date must be greater than Issue Date");
        return false;
    }
    else if (!returnEntryExit) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("The Visa Exit Date must be greater than Entry Date");
        return false;
    }
    else if (!returnFamilyEntryExit) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("The  Family Visa Exit Date must be greater than Entry Date");
        return false;
    }
    else if (!returnVal) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please fill all mandatory fields");
        return false;
    }
    else if (returnVal && !returnMail) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please Provide a Valid E-mail");
        return false;
    }
    else if (returnVal && !returnDob) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please Provide a Valid DoB");
        return false;
    }
    else if (returnVal && !returnPhNo) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please Provide a Valid Phone Number");
        return false;
    }
    else if (returnVal && !returnFax) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please Provide a Valid Fax Number");
        return false;
    }
    else if (returnVal && !returnDate) {

        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please Provide a Valid Date (MM/DD/YYYY)");
        return false;

    }
    else if (returnVal && !returnEDate) {

        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please Provide a Date Greater Than The Entered Date");
        return false;

    } else if (returnVal && !returnNumeric) {
        $("#" + label).addClass("lblError");
        $("#" + label).removeClass("lblMessage");
        $("#" + label).text("Please Provide a Valid Numeric value");
        return false;
    }
    else if (returnVal) {
        $("#" + label).text("");
        $("#" + label).removeClass("lblError");
        $("#" + label).addClass("lblMessage");
    }
    return returnVal;
}

function CheckIsNotSelected(id, divId) {                            //Restrict duplicates in people picker
    var notExist = true;
    $(divId).find('.divcompetancy').each(function () {
        if (parseInt($(this).attr('name')) == parseInt(id)) {
            notExist = false;
        }
    });
    return notExist;
}
function CreateCheckBox(obj, checkBoxVal, labelName) {
    var IsPresent = false;
    obj.find('.resourcemoreusename').each(function () {
        if ($(this).text() == checkBoxVal)
            IsPresent = true; //indicates value is already there in checkbox - to avoid duplicates
    });
    if (!IsPresent) {
        obj.append("<div class='moreresourcediv LoadedVal'>" +
                       "<table width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                           "<tbody>" +
                               "<tr>" +
                                   "<td width='10%'><div><input type='checkbox' class='cbcheckbox' id='cb" + checkboxNum + "'></div></td>" +
                                   "<td width='90%'><div class='resourcemoreusename'><label title='" + checkBoxVal + "' class='cbcheckbox' for='cb" + checkboxNum + "' name='" + labelName + "'>" +
                                    checkBoxVal + "</label></div></td>" +
                               "</tr>" +
                           "</tbody>" +
                       "</table>" +
                   "</div>");
        checkboxNum++;
    }
}
//Employee rating monthly view next and previous clicks
function RatingPrevious(obj) {
    var monthYr = $(obj).closest('table').find('#EmpRatingmonthYeardiv')[0].innerText;
    var mon = months.indexOf(monthYr.split(' ')[0]) + 1;
    var yr = parseInt(monthYr.split(' ')[1]);
    if (mon == 1) {
        yr = parseInt(yr) - 1;
        mon = 13
    }
    loadEmployeeRatings(yr, mon - 1);
}
function RatingNext(obj) {
    var monYr = $(obj).closest('table').find('#EmpRatingmonthYeardiv')[0].innerText;
    var mon = months.indexOf(monYr.split(' ')[0]) + 1;
    var yr = parseInt(monYr.split(' ')[1]);
    if (mon == parseInt(dt.getMonth() + 1) && yr == dt.getFullYear()) {
        $('#divEmpRatingNext').attr('disabled', true);
    }
    else {
        if (mon == 12) {
            yr = parseInt(yr) + 1;
            mon = 0
        }
        loadEmployeeRatings(yr, mon + 1);
    }
}

function DefineCompetancies(listObject, inputObject) {
    inputObject.keypress(function (e) {
        var key = e.which;
        if (key == 13) {
            var inputText = $(this).val();
            if (inputText != "") {
                listObject.append("<div class='div2'><div style='padding-left:2px;margin: 0; font-size: 11px; color: #fff; min-width: 50px; width:auto; float: left;'><label class='divcompetancy'>" + inputText +
                            "</label></div><div style='margin: 0; font-size: 11px; color: #fff; height: 10px;  width:10px; float: left; '>" +
                                        "<a title='Close' href='#' style='color: #fff;' onclick='this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);'>X</a></div></div>");
                $(this).val("");
                PreventDefaultClick();
            }
        }
    });
    inputObject.focusout(function (e) {
        var inputText = $(this).val();
        if (inputText != "") {
            listObject.append("<div class='div2'><div style='padding-left:2px;margin: 0; font-size: 11px; color: #fff; min-width: 50px; width:auto; float: left;'><label class='divcompetancy'>" + inputText +
                        "</label></div><div style='margin: 0; font-size: 11px; color: #fff; height: 10px;  width:10px; float: left; '>" +
                                    "<a title='Close' href='#' style='color: #fff;' onclick='this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);'>X</a></div></div>");
            $(this).val("");
        }
    });
}

function getCompetancy(element) {
    var returnVal = "";
    element.find(".divcompetancy").each(function () {
        returnVal = returnVal + $(this).text() + "|";
    });
    return returnVal;
}

function CheckExceptionTexts(input, ColValue, ColFieldNumber, defaultVal) {
    if ((ColValue == ColFieldNumber) && input == 'NA')
        input = defaultVal; //convert NA case to default date
    return input;
}
//Pagination functions
function disableButtons(LastButton, NextButton, FirstButton, PreviousButton, PageCount, CurrentPageId) {
    if (CurrentPageId == PageCount) {
        LastButton.css('pointer-events', 'none');
        NextButton.css('pointer-events', 'none');
    }
    else {
        LastButton.css('pointer-events', 'visible');
        NextButton.css('pointer-events', 'visible');
    }
    if (CurrentPageId == 1) {
        FirstButton.css('pointer-events', 'none');
        PreviousButton.css('pointer-events', 'none');
    }
    else {
        FirstButton.css('pointer-events', 'visible');
        PreviousButton.css('pointer-events', 'visible');
    }
}
function hidePages(PaginationDivId, ActiveClassName, PageNum) {
    PaginationDivId.each(function () {
        $(ActiveClassName + PageNum).hide();
        PageNum = PageNum + 1;
    });
}
function showPages(PaginationDivId, ActiveClassName, PageNum) {
    PaginationDivId.each(function () {
        $(ActiveClassName + PageNum).show();
        PageNum = PageNum + 1;
    });
}
function ShowPreviousPage(Paginationbtn, ClassName, ActiveClass, ActiveClassTwodgt, ActiveClassThreedgt) {
    if (classId == 5 && loopVal > 5) {
        AddAndRemoveClass(loopVal - 1, classId, Paginationbtn, $(ClassName + classId),
            ActiveClass, ActiveClassTwodgt, ActiveClassThreedgt);
        loopVal = loopVal - 5;
        Paginationbtn.each(function () {
            $(this).text(loopVal);
            loopVal = loopVal + 1;
        });
    }
    else
        AddAndRemoveClass(loopVal, (classId - 1), Paginationbtn, $(ClassName + (classId - 1)),
            ActiveClass, ActiveClassTwodgt, ActiveClassThreedgt);
}
function getLoopValAndClassId(ActiveClassName, ActiveClassNameTwodgt, ActiveClassNameThreeDgt) {
    if (ActiveClassName.length != 0 && ActiveClassNameTwodgt.length == 0 && ActiveClassNameThreeDgt.length == 0) {
        classId = parseInt(ActiveClassName.attr("name"));
        loopVal = parseInt(ActiveClassName.text());
    }
    else if (ActiveClassNameTwodgt.length != 0 && ActiveClassName.length == 0 && ActiveClassNameThreeDgt.length == 0) {
        classId = parseInt(ActiveClassNameTwodgt.attr("name"));
        loopVal = parseInt(ActiveClassNameTwodgt.text());
    }
    else {
        classId = parseInt(ActiveClassNameThreeDgt.attr("name"));
        loopVal = parseInt(ActiveClassNameThreeDgt.text());
    }
}
function FirstButonClick(btnClass, paginationNumClass, ActiveClassName, CurrentPageId, ActiveCLassTwodgt, ActiveClassThreedgt) {
    loopVal = CurrentPageId;
    btnClass.each(function () {
        $(this).text(loopVal);
        loopVal = loopVal + 1;
    });
    AddAndRemoveClass(1, 1, btnClass, paginationNumClass, ActiveClassName, ActiveCLassTwodgt, ActiveClassThreedgt)
}
function LastButtonClick(btnClass, paginationNumClass, LastPageId, ActiveClassName, CurrentPageId, ActiveCLassTwodgt, ActiveClassThreedgt) {
    if (CurrentPageId > 5) {
        loopVal = CurrentPageId - 4;
        btnClass.each(function () {
            if (CurrentPageId >= loopVal) {
                $(this).text(loopVal);
                loopVal = loopVal + 1;
            }
        });
        AddAndRemoveClass(CurrentPageId, 5, btnClass, paginationNumClass, ActiveClassName, ActiveCLassTwodgt, ActiveClassThreedgt);
    }
    else {
        loopVal = CurrentPageId - (CurrentPageId - 1);
        btnClass.each(function () {
            if (CurrentPageId >= loopVal) {
                $(this).text(loopVal);
                loopVal = loopVal + 1;
            }
        });
        AddAndRemoveClass(CurrentPageId, CurrentPageId, btnClass, LastPageId, ActiveClassName, ActiveCLassTwodgt, ActiveClassThreedgt);
    }
}
function AddAndRemoveClass(loopVal, classId, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt) {
    if ((loopVal.toString().length == 1)) {
        btnClass.removeClass(ActiveClassName);
        btnClass.removeClass(ActiveClassTwodgt);
        btnClass.removeClass(ActiveClassThreedgt);
        paginationNumClass.addClass(ActiveClassName);
    }
    else if ((loopVal.toString().length == 2)) {
        btnClass.removeClass(ActiveClassTwodgt);
        btnClass.removeClass(ActiveClassName);
        btnClass.removeClass(ActiveClassThreedgt);
        paginationNumClass.addClass(ActiveClassTwodgt);
    }
    else {
        btnClass.removeClass(ActiveClassTwodgt);
        btnClass.removeClass(ActiveClassName);
        btnClass.removeClass(ActiveClassThreedgt);
        paginationNumClass.addClass(ActiveClassThreedgt);
    }
}
function NextButtonClick(btnClass, paginationNumClass, LastPageId, ActiveClassName, pageCount, ActiveClassTwodgt, ActiveClassThreedgt) {
    var currentText = loopVal;
    if (loopVal >= 4 && classId == 4 && (loopVal + 1) < pageCount) {
        loopVal = loopVal - 2;
        btnClass.each(function () {
            $(this).text(loopVal);
            loopVal = loopVal + 1;
        });
        AddAndRemoveClass(currentText + 1, classId, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
    }
    else
        AddAndRemoveClass(currentText+1, classId + 1, btnClass, LastPageId, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
}
function prevButtonClick(btnClass, paginationNumClass, LastPageId, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt, CurrentPageId) {
    var currentText = loopVal;
    if ((classId == 5 || classId > 2 || loopVal == 2) && loopVal >= classId) {
        AddAndRemoveClass(currentText - 1, classId - 1, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
    }
    else if (classId == 2 && loopVal >= classId) {
        loopVal = loopVal - classId;
        btnClass.each(function () {
            $(this).text(loopVal);
            loopVal = loopVal + 1;
        });
        AddAndRemoveClass(currentText - 1, classId, btnClass, LastPageId, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
    }
    else
        AddAndRemoveClass(currentText - 1, classId - 1, btnClass, paginationNumClass, ActiveClassName, ActiveClassTwodgt, ActiveClassThreedgt)
}
function showAndHidePages(PageCount, PageId, paginationBtndiv, className) {
    if (PageCount <= 5) {
        loopVal = 1;
        if (loopVal <= PageCount && PageId <= PageCount) {
            showPages(paginationBtndiv, className, loopVal);
        }
        hidePages(paginationBtndiv, className, (PageCount + 1));
    }
    else {
        showPages(paginationBtndiv, className, loopVal);
    }
}
function LoadEachButton(PaginationBtnName, PaginationBtnClass, ActivaClassSingleDgt, ActiveClassTwoDgt, ActiveClassThreeDgt,PageCount) {
    if (classId == 1) {
        if (loopVal == 1) {
            AddAndRemoveClass(loopVal, classId, PaginationBtnName, $(PaginationBtnClass + classId), ActivaClassSingleDgt,
             ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        else {
            AddAndRemoveClass(loopVal, classId + 1, PaginationBtnName, $(PaginationBtnClass + (classId + 1)), ActivaClassSingleDgt,
             ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        loopVal = loopVal - 1;
        PaginationBtnName.each(function () {
            if (loopVal > 0) {
                $(this).text(loopVal);
                loopVal = loopVal + 1;
            }
        });
    }
    else if (classId == 5) {
        if (loopVal == PageCount) {
            AddAndRemoveClass(loopVal, classId, PaginationBtnName, $(PaginationBtnClass + classId), ActivaClassSingleDgt,
             ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        else {
            AddAndRemoveClass(loopVal, classId - 1, PaginationBtnName, $(PaginationBtnClass + (classId - 1)), ActivaClassSingleDgt,
             ActiveClassTwoDgt, ActiveClassThreeDgt);
        }
        if (loopVal != PageCount) {
            loopVal = loopVal - 3;
            PaginationBtnName.each(function () {
                if (loopVal <= PageCount) {
                    $(this).text(loopVal);
                    loopVal = loopVal + 1;
                }
            });
        }
    }
    else {
        AddAndRemoveClass(loopVal, classId, PaginationBtnName, $(PaginationBtnClass + classId), ActivaClassSingleDgt,
         ActiveClassTwoDgt, ActiveClassThreeDgt);
    }
}
function hideFilter()
{
    $('.paginationbtndiv').click(function (e) {
        $('.slidingDivGrid').hide();
    });
}

function AppendFilesWithTag(docElement, filename, accesspath, closebuttondiv, divDocuments, classnumber, TagVal, ControlType) {
    var extensionImage = "";
    var fileNameVal = accesspath.split('/').pop();
    var extension = fileNameVal.substr((fileNameVal.lastIndexOf('.') + 1));
    extensionImage = "../Images/pdf-icon.png";
    //switch (extension) {
    //    case 'xlsx':
    //    case 'xlsm':
    //    case 'xls':
    //        extensionImage = "../Images/excel.png";
    //        break;
    //    case 'doc':
    //    case 'docx':
    //    case 'dot':
    //        extensionImage = "../Images/word.png";
    //        break;
    //    case 'pdf':
    //        extensionImage = "../Images/pdf-icon.png";
    //        break;
    //    default:
    //        extensionImage = "../Images/NoImage.jpg";
    //        break;
    //}
    var Control = "";
    var TagValue = TagVal == null ? "" : TagVal;
    if (ControlType == 1)
        Control = "<input class='floating-input txtTagName' value = '" + TagValue + "' type='text'/>";
    else if (TagValue != "")
       Control = "<div class='visatexboxviewdiv'><p>'" + TagValue + "'</p></div>";
    fileNameVal = fileNameVal.indexOf('^_^_^') >= 0 ? fileNameVal.split('^_^_^')[0] + "." + extension : fileNameVal;
    //docElement.append("<div id='" + expFileNum + "' class='col-sm-" + classnumber + "'><div class='profilethumbnaildiv'>" +
    //    closebuttondiv + "<input type='hidden' id='hdnProPicFile' value='" + accesspath + "' class='filehidden' /><a href='" +
    //    accesspath + "' target='_blank'><img class='profilethumbnaildiv' src='" + extensionImage +
    //    "' /></a><a href='" + accesspath + "' target='_blank'><div class='profilepictext documentname' title='" +
    //    fileNameVal + "'>" + fileNameVal + "</div></a></div></div>");
    docElement.append("<div id='" + expFileNum + "' class='"+(ControlType == 1 ? "visaprocessingmaindiv" : "visaprocessingmaindivView" )+"'>" + closebuttondiv +
                                "<input type='hidden' id='hdnProPicFile' value='" + accesspath + "' class='filehidden' />" +
                                "<div class='visaprocessingicon'><a href='" + accesspath + "' target='_blank'>" +
                                "<img src='" + extensionImage + "' width='32px' height='32px' alt='' ></div></a>" +
                                "<div class='visadocumentname' title='" +
                                fileNameVal + "'><a href='" + accesspath + "' target='_blank'>" + fileNameVal + "</a></div>" +
                                "<div class='visatexboxdiv'>" + Control + "</div>" +
                            "</div>");
    expFileNum = expFileNum + 1;
    if (divDocuments != null)
        divDocuments.show();
    if (ControlType == 1)
        defineCloseButton();
}








