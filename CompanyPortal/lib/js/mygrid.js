
    
$(document).ready(function () {

    
    $("#grid").jqGrid(

        {

            url: "/ProjectJQGrid/GetProjects",

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
                expandOnLoad:true
            }


        }).navGrid('#pager', { edit: true, add: true, del: true, search: true, refresh: true });


});
    

// the event handler on expanding parent row receives two parameters
// the ID of the grid tow  and the primary key of the row
function showChildGrid(parentRowID, parentRowKey) {
    // create unique table and pager
    var childGridID = parentRowID + "_table";
    var childGridPagerID = parentRowID + "_pager";

    // send the parent row primary key to the server so that we know which grid to show
    var childGridURL = "/ProjectJQGrid/getTeamDetails";
    // add a table and pager HTML elements to the parent grid row - we will render the child grid here
    $('#' + parentRowID).append('<table id=' + childGridID + '></table><div id=' + childGridPagerID + '></div>');

    $("#" + childGridID).jqGrid({
        url: childGridURL,
        mtype: "GET",
        datatype: "json",
        page: 1,
        colNames: ['UserId', 'EmployeeName', 'EmailId'],
        colModel: [
            { label: 'UserId', name: 'UserId', key: true, width: 75 },
            { label: 'name', name: 'name', width: 100 },
            { label: 'emailid', name: 'emailid', width: 100 }
        ],
        loadonce: true,
        width: 500,
        height: '100%',
        pager: "#" + childGridPagerID,
        caption: "Project Details",
        emptyrecords: "No projects to show",
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
