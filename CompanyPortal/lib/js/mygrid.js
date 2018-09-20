
    
$(document).ready(function () {
    debugger

  

});
    


function jqgridInitialize(status) {
    debugger
    $("#grid").setGridParam({ datatype: 'json', url: "/ProjectJQGrid/GetProjects?status=" + status});
    
    $("#grid").trigger("reloadGrid")

    $("#grid").jqGrid(
        {
            url: "/ProjectJQGrid/GetProjects?status="+status,
            datatype: "json",
            mtype: "Get",
            colNames: ['PId', 'Project_Name', 'Mgr_Id', 'Status'],
            colModel: [
                { key: true, name: 'PId', index: 'PId', editable: false },
                { key: false, name: 'Project_Name', index: 'Project_Name', editable: true },
                { key: false, name: 'Mgr_Id', index: 'Mgr_Id', editable: true },
                { key: false, name: 'Status', index: 'Status', editable: true }
            ],
            pager: jQuery('#pager'),
            rowNum: 5,
            rowList: [5, 10, 15, 20],
            height: "100%",
            viewrecords: true,
            caption: "Project Details",
            emptyrecords: "No projects to show",
            setsearchtoobar: true,
            loadOnce: true,
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            autowidth: true,
            subGrid: true,
            subGridRowExpanded: showChildGrid,
            subGridOptions: {
                expandOnLoad: false
            }


        }).navGrid('#pager', { edit: true, add: true, del: true, search: true, refresh: true });


}
// the event handler on expanding parent row receives two parameters
// the ID of the grid tow  and the primary key of the row
function showChildGrid(parentRowID, parentRowKey) {
    debugger
  
    // create unique table and pager
    var childGridID = parentRowID + "_table";
    var childGridPagerID = parentRowID + "_pager";

    // send the parent row primary key to the server so that we know which grid to show
    var childGridURL = "/ProjectJQGrid/getTeamDetails?pid=" + parentRowKey;
    // add a table and pager HTML elements to the parent grid row - we will render the child grid here
    $('#' + parentRowID).append('<table id=' + childGridID + '></table><div id=' + childGridPagerID + '></div>');
  //  $("#" + childGridID).setGridParam({ datatype: 'json', url: childGridID }).trigger("reloadGrid");

    $("#" + childGridID).jqGrid({
        url: childGridURL,
        mtype: "GET",
        datatype: "json",
        page: 1,
        colNames: ['UserId', 'EmployeeName', 'EmailId'],
        colModel: [
            { label: 'userId', name: 'userId', key: true, width: 75 },
            { label: 'Firstname', name: 'Firstname', width: 100 },
            { label: 'Email', name: 'Email', width: 100 }
        ],
        
        width: 500,
        height: '100%',
        pager: "#" + childGridPagerID,
        caption: "Team Details",
        emptyrecords: "No projects to show",
        onSelectRow: exapandEmployeeDetail,
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
    });
}


