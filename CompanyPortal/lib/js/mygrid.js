
    
$(document).ready(function () {
    debugger

    $("#grid").extend(jQuery.jgrid.defaults, {

        prmNames: {
            id: "_rowid", page: "_page", rows: "_rows",
            oper: "_oper", sortname: "_sidx", sord: "_sord"
        }
    });

});
    


function jqgridInitialize(status) {
    debugger
    $("#grid").setGridParam({ datatype: 'json', url: "/ProjectJQGrid/GetProjects?status=" + status});
    
    $("#grid").trigger("reloadGrid")

    $("#grid").jqGrid(
        {
            url: "/ProjectJQGrid/GetProjects?status=" + status,
            datatype: "json",
            mtype: "Get",
            colNames: ['Project Name', 'Manager Id', 'Status','Actions'],
            colModel: [
                {
                    key: false, name: 'Project_Name', index: 'Project_Name', editable: true, search: true
                    , searchoptions: { sopt: ['eq'] }, sortable: true,sorttype:'text'
                },
                { key: false, name: 'Mgr_Id', index: 'Mgr_Id', editable: true, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text'},
                { key: false, name: 'Status', index: 'Status', editable: true, search: true, searchtype: 'string', sortable: true, sorttype: 'text' },
                { key: false, name: 'Actions', index: 'Actions', editable: false, formatter: displayButtons }

            ],
            pager: jQuery('#pager') ,
            rowNum: 5,
            searchfield: "Project_Name",
            seachstring: "abcd",
            sortname:"jyot",
            rowList: [5, 10, 15, 20],
            height: "100%",
            viewrecords: true,
            caption: "Project Details",
            emptyrecords: "No projects to show",
            
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


        }).navGrid('#pager', { edit: true, add: true, del: true, search: false, refresh: true });

    $("#grid").jqGrid('filterToolbar', {
        autosearch: true,
        stringResult: false,
        searchOnEnter: true,
        searchOperators: true

    });

  

    var maxNameLength = 10;
    $("input[id=gs_Project_Name]").blur(function () {
        debugger
        var $th = $(this).closest(".ui-search-toolbar>th"),
            colIndex = $th[0].cellIndex,
            $colHeader = $th.parent().siblings(".ui-jqgrid-labels").children("th").eq(colIndex),
            colHeaderText = $colHeader.children("div").text();
        var searchString = $(this).val();
        $("#grid").setGridParam({ datatype: 'json', mtype: "POST", postData: { "searchField": colHeaderText, "searchString": searchString } }).trigger("reloadGrid");


        if (this.value.length > maxNameLength) {
            alert(colHeaderText + ' is longer than ' + maxNameLength + ' characters.');
        }


    });


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

//custom formator function to display the Links
function displayButtons(cellvalue, options, rowObject) {
    var edit = "<a href='#'>Edit</a>",
        Details = "<a href='#'>Details</a> |",
        Delete = "<a href='#'>Delete</a>";
    return edit + Details + Delete;
}


function ToggleColumn(role_) {
    if (role_ == "Member") {
        jQuery("#grid").jqGrid('hideCol', ["Actions"]);
    }
    else if (role_ == "Admin") {
        jQuery("#grid").jqGrid('showCol', ["Actions"]);    
    }
}

