﻿

function AttendencejqgridInitialize(userid) {
    debugger
  /*  $("#grid").setGridParam({ datatype: 'json', url: "/ProjectJQGrid/GetProjects?status=" + status, postData: { Search: false } });

    $("#search").val("");


    $("#grid").trigger("reloadGrid");
*/

    $("#AttendGrid").jqGrid(
        {
            url: "/AttendenceJQGrid/GetAttendence?userid=" + userid,
            datatype: "json",
            mtype: "Get",
            postData: "",
            colNames: [ '','Date', 'LogIn Time', 'LogOut Time','Duration','Attendence Status'],
            colModel: [

                { key: true, name: 'PId', index: 'PId', width: -1, editable: false,
                    hidden: true,
                    editoptions: {
                        dataInit: function (element) {
                            jq(element).attr("readonly", "readonly");
                        }
                    }
                },

              //  { key: false, name: 'Actions', index: 'Actions', width: 15, align: "center", editable: false, formatter: displayButtons, search: false },
              
                { key: false, name: 'Date', index: 'Date', edtable: false, search: true
                    , searchoptions: { sopt: ['cn'] }, sortable: true, sorttype: 'date', formatter: 'date', formatoptions: { }
                },

                { key: false, name: 'LogInTime', index: 'LogInTime', editable: false, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text' },

                { key: false, name: 'LogOutTime', index: 'LogOutTime', editable: false, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text' },

                { key: false, name: 'TotalTime', index: 'TotalTime', editable: false, search: false,  formatter: displayTime },

                { key: false, name: 'AttendenceStatus', index: 'AttendenceStatus', editable: true, search: true, searchtype: 'string', sortable: true, sorttype: 'text', search: false }

            ],
            pager: jQuery('#AttendPager'),
            rowList: [5, 10, 15, 20],
            rowNum: 20,
            height: "100%",
            viewrecords: true,
            caption: "Attendence",
            emptyrecords: "No projects to show",
            loadOnce: true,
            ignoreCase: true,


            onSortCol: function (name, index, order) {
                debugger
                $("#grid").setGridParam({ postData: { "SortBy": name, "OrderBy": order } });
               
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

function displayTime(cellvalue, options, rowObject) {
    debugger
    if (cellvalue != null) {
        var TotalTime = cellvalue.split(":");
        return TotalTime[0] + " hrs " + TotalTime[1] + " minutes";
    }
    else
        return "0 hrs";
    
}