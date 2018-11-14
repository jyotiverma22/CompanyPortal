function InitializeEmployeeGrid() {

    $("#EmpGrid").jqGrid(
        {
            url: "/EmployeeJqGrid/GetEmployees" ,
            datatype: "json",
            mtype: "Get",
            postData: "",
            colNames: ['Emp Id', 'Name', 'Email', 'Joining Date', ''],
            colModel: [

                {
                    key: true, name: 'UserId', index: 'UserId', width: 50, editable: false,
                    hidden: false, resizable: false,
                    editoptions: {
                        dataInit: function (element) {
                            jq(element).attr("readonly", "readonly");
                        }
                    }
                },

                //  { key: false, name: 'Actions', index: 'Actions', width: 15, align: "center", editable: false, formatter: displayButtons, search: false },

                {
                    key: false, name: 'FullName', index: 'FullName', search: true
                    , sortable: true, sorttype: 'string', resizable: false
                },

                { key: false, name: 'Email', index: 'Email', resizable: false, editable: false, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text' },

                { key: false, name: 'JoiningDate', index: 'JoiningDate', resizable: false, editable: false, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text', formatter: 'date' },

                { key: false, name: 'Actions', index: 'Actions', resizable: false, formatter: DisplayButtonsforShowingDetails, sortable: false }

            ],
            pager: jQuery('#EmpPager'),
            rowList: [5, 10, 15, 20],
            rowNum: 20,
            height: "100%",
            viewrecords: true,
            caption: "Employees",
            emptyrecords: "No Employees to show",
            loadOnce: true,
            ignoreCase: true,


            onSortCol: function (name, index, order) {
                debugger
                $("#EmpGrid").setGridParam({ postData: { "SortBy": name, "OrderBy": order } }).trigger("reloadGrid");

            },


            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            autowidth: true,
            loadComplete: function () {
                debugger
                $("tr.jqgrow:odd").addClass('myAltRowClass');

            }

        });

}

function DisplayButtonsforShowingDetails(cellvalue, options, rowObject) {
    debugger
    var attendence = ' <Button href="#" onclick="ShowEmpsAttendence(this,\'' + rowObject.UserId +'\')" ><span>Attendence </span></Button>';
    var FullDetails = ' <Button href="#" onclick="ShowEmpsDetails(\'' + options.rowId + '\')" ><span>Full Details </span></Button>';
    return attendence + FullDetails;
    return "format";
}

function ShowEmpsAttendence(element,userid) {
    debugger
    $("#attend").show();
    AttendencejqgridInitialize(userid);
    $("#btnBack").show();
    $("#ShowEmpToAdmin").hide();
}

function ShowEmpsDetails(userid) {
    exapandEmployeeDetail(userid);
}