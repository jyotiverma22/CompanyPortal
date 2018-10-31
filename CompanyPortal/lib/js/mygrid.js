
var a = 0;
 //intializing the jqgrid for project details   
function jqgridInitialize(status) {
    debugger
    $("#grid").setGridParam({ datatype: 'json', url: "/ProjectJQGrid/GetProjects?status=" + status, postData: { Search: false } });

    $("#search").val("");
    //$()
    
    $("#grid").trigger("reloadGrid");

  
    $("#grid").jqGrid(
        {
            url: "/ProjectJQGrid/GetProjects?status=" + status,
            datatype: "json",
            mtype: "Get",
            postData:"", 
            colNames: ['','','Project Name', 'Manager Id', 'Status'],
            colModel: [
                { key: false, name: 'Actions', index: 'Actions', width: 15, align: "center", editable: false, formatter: displayButtons, search: false },
                { key:true,  name: 'PId',index: 'PId',width: 100, editable: false,  editrules: {
                        required: true,
                        edithidden: true
                    },
                    hidden: true,
                    editoptions: {
                        dataInit: function (element) {
                            jq(element).attr("readonly", "readonly");
                        }
                    }
                },
                {
                  key: false, name: 'Project_Name', index: 'Project_Name', editable: true, search: true
                    , searchoptions: { sopt: ['cn'] }, sortable: true,sorttype:'text'
                },
                { key: false, name: 'Mgr_Id', index: 'Mgr_Id', editable: true, search: true, searchtype: 'string', sortable: true, firstsortorder: 'desc', sorttype: 'text'},
                { key: false, name: 'Status', index: 'Status', editable: true, search: true, searchtype: 'string', sortable: true, sorttype: 'text',search:false }
             
            ],
            pager: jQuery('#pager') ,              
            rowList: [5, 10, 15, 20],
            rowNum:20,
            height: "100%",
            viewrecords: true,
            caption: "Project Details",
            emptyrecords: "No projects to show",            
            loadOnce: true,
            ignoreCase:true,
           

            onSortCol: function (name, index,order) {
                debugger
                $("#grid").setGridParam({ postData: { "SortBy": name, "OrderBy":order } });
                //s = $("#grid").getGridParam('selarrrow');
               // $("#grid").jqGrid('setSelection', 1,true)
              //  alert(s);
            },
            ondblClickRow: function (id) {
                debugger    
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
            subGrid: true,
            subGridRowExpanded: showChildGrid,
            subGridOptions: {
                expandOnLoad: false
            },

            loadComplete: function () {
                debugger
                $("tr.jqgrow:odd").addClass('myAltRowClass');
                if (a == 0) {
                    $('.ui-jqgrid-title').after('<div id="jqGridButtonDiv"><input type="text" name="search" id="ProjectSearchID" onkeypress="EnterPressedOnSearchBox(event) "> <a href="#" onclick="SearchInProject()" class="fa fa-search" id="SearchButton"></a> </div>');

                    a = 1;
                }
                
            }

        });

    

  /*  $("#grid").jqGrid('filterToolbar', {

        searchOperators: true,
        stringResult: true,
        searchOnEnter: true,
        autoSearch: false,
        groupOp: "AND",
        beforeSearch: function () {
            debugger
            var rules = [], i, cm, postData = $("#grid").jqGrid("getGridParam", "postData"),
                colModel = $("#grid").jqGrid("getGridParam", "colModel");        
            for (i = 0; i < colModel.length; i++) {
                cm = colModel[i];
                if (cm.search !== false && (cm.stype === undefined || cm.stype === "text")) {
                    rules.push({
                        field: cm.name,
                        op: "cn",
                        data:$.trim( $("input[id=gs_" + cm.name + "]").val())
                    });
                }
            }
            $("#grid").setGridParam({
                mtype: "POST", postData: {
                    "filters": {
                        groupOp: "OR",
                        rules: rules
                    },
                    _search:true
                }
            }).trigger("reloadGrid");

        },

        afterSearch: function () {
            //to empty the search boxes after search

            var colModel = colModel = $("#grid").jqGrid("getGridParam", "colModel");
            for (var i = 0; i < colModel.length; i++) {
                $("input[id=gs_" + colModel[i].name + "]").val("");
            }
        }

    }); */
}



// the event handler on expanding parent row receives two parameters
// the ID of the grid tow  and the primary key of the row
function showChildGrid(gid,rowId) {
    debugger
 //   var gridId = gid.id;
    var parentRowID = gid;
    // create unique table and pager
    var childGridID = parentRowID + "_table";
    var childGridPagerID = parentRowID + "_pager";

    // send the parent row primary key to the server so that we know which grid to show
    var childGridURL = "/ProjectJQGrid/getTeamDetails?pid=" + rowId;
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
        rowNum: 5,
        pager: "#" + childGridPagerID,
        caption: "Team Details",
        emptyrecords: "No projects to show",
        onSelectRow: exapandEmployeeDetail,
    
        loadComplete: function () {
            debugger
            var gridid = "gview_grid_" + rowId + "_table";
            var childgridtitle = document.getElementById(gridid).childNodes[0].childNodes[1]
            $(childgridtitle).after('<div id="jqSubGridButtonDiv"> <a href="#" onclick="" class="fa fa-user-plus"></a> </div>');


        },
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
 
    var value = "<a href='#' onclick='showEditingDIV(event," + rowObject.PId + ",this)' class='fa fa-ellipsis-v relativeDiv editdiv' id=r" + rowObject.PId + "></a>"; 
    
    return value;
}

// to show and hide the action links
function ToggleColumn(role_) {
    if (role_ == "Member") {
        jQuery("#grid").jqGrid('hideCol', ["Actions"]);
    }
    else if (role_ == "Admin") {
        jQuery("#grid").jqGrid('showCol', ["Actions"]);    
    }
}



//custom fuction for adding team member
function AddTeamMembers(item) {
    var rowid = $(item).closest("tr").attr("id");

}



//function to search in projects

function SearchInProject()
{
    debugger
   // var a = item.parent();
//    var value = document.getElementById($(item).parent().attr("id")).childNodes[0].value;
    var value = $("#ProjectSearchID").val();
    var postdata = $("#grid").jqGrid('getGridParam', 'postData');
    $("#grid").setGridParam({ mtype: "POST", postData: { Search: true, SearchValue: value } }).trigger("reloadGrid");


}

function EnterPressedOnSearchBox(e) {
   debugger
    var key = e.charCode || e.keyCode || 0;
    if (key === $.ui.keyCode.ENTER) {
        $("#SearchButton").click();
    }
}

function showEditingDIV(event,PId,element) {
    debugger
    $("#contextMenu1").fadeIn(100);
    $("#contextMenu1").css({ 'top': event.pageY - 50 });

    $('#view').off('click');
    $('#edit').off('click');
    $('#del').off('click');

    $("#view").on("click", { msg: PId }, ShowProjectDetails);
    $("#edit").on("click", { msg: PId }, EditProjectDetail);
    $("#del").on("click", { msg: PId }, deleteProject);

}

function ShowProjectDetails(event) {
  //    alert(event.data.msg);
    var dialog = $('<div id="ShowParticularProject" title="Project Details"> </div>');
    dialog.dialog({
        modal: true,
        autoOpen: true,
        resizable: false,
        open: function () {
            $(this).load("LoggedIn/ShowParticularProjectDetails?pid=" + event.data.msg);
        },
       
    });
    dialog.dialog("open");
    return false;

}

function EditProjectDetail(event) {
  
   // alert(event.data.msg);
    var pid = event.data.msg
    //custom dialog box on edit action link 
    $("#editprojectdetaildialog").dialog({
        autoOpen: false,
        title: "Edit Project Details",
        modal: true,
        open: function (event, ui) {
            debugger
            $(this).load("LoggedIn/AddProject?pid=" +pid);
        }
      

    });

    $("#editprojectdetaildialog").dialog("open");


}

function deleteProject(event) {
//    alert(event.data.msg);
    var pid = event.data.msg;
    var dialog = $('<div id="delete_Confirm_dialog" title="Add Team Members"> Are You Sure? </div>');
    dialog.dialog({
        modal: true,
        autoOpen: true,
        resizable: false,
        
        buttons: [
            {
                text: 'Yes',
                click: function () {
                    $('#delete_Confirm_dialog').remove();
                    $.post("/LoggedIn/DeleteProject?pid=" + pid + "&userid=", function (data) {
                        debugger
                        if (data == true) {
                            $("#grid").trigger("reloadGrid");
                        }
                    });
                }
            },
            {
                text: 'No',
                click: function () {
                    $('#delete_Confirm_dialog').remove();
                  
                }
            }
        ]
    });


    dialog.dialog("open");
 
}



$(document).ready(function () {
    $(document).mouseup(function (e) {
        var container = new Array();
        container.push($('#contextMenu1'));

        $.each(container, function (key, value) {
            if (!$(value).is(e.target) // if the target of the click isn't the container...
                && $(value).has(e.target).length === 0) // ... nor a descendant of the container
            {
                $(value).hide();
            }
        });
    });
})