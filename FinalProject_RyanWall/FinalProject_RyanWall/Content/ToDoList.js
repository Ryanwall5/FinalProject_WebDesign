var rh = rh || {};

rh.list = rh.list || {};

rh.list.editing = false;

rh.list.attacheventhandler = function () {
    console.log("called attacheventhandler");
    //shown.bs.modal is a event that gets called when you open the modal
    $("#insert-List-Item-Modal").on('shown.bs.modal', function () {
        console.log("called shown.bs.modal");
        $("input[name=NameOfDuty]").focus();

    });
};


rh.list.enablebuttons = function () {

    $("#toggle-edit").click(function () {
        if (rh.list.editing) {
            rh.list.editing = false;
            $(".edit-actions").addClass("hidden");
            $(this).html("Edit");

        } else {
            rh.list.editing = true;
            $(".edit-actions").removeClass("hidden");
            $(this).html("Done");
        }
    });

    $("#add-list-item").click(function () {

        $("#insert-List-Item-Modal .modal-title").html("Add a List Item");
        $("#insert-List-Item-Modal button[type=submit]").html("Add Item");

         $("#insert-List-Item-Modal input[name=NameOfDuty]").val("");
         $("#insert-List-Item-Modal input[name=Date]").val("");
         $("#insert-List-Item-Modal input[name=DateToFinish]").val("");
         //$("#insert-List-Item-Modal input[name=IsChecked]").val("");
         $("#insert-List-Item-Modal input[name=ToDoListId]").val("").prop("disabled", true);
       
    });

   
    $(".edit-list-item").click(function () {
        $("#insert-List-Item-Modal .modal-title").html("Edit This List Item");
        $("#insert-List-Item-Modal button[type=submit]").html("Edit List");


        id = $(this).find(".id").html();
        
        name = $(this).find(".name").html();
       
        date = $(this).find(".date").html();
       
        dateto = $(this).find(".datetofinish").html();
        
        var check = $(this).find(".ischecked").html();

        console.log("checked = " + check);
       //var x = document.getElementsByName("IsChecked");

        var check1 = (check == "True");
        //console.log("checked1 = " + check1);
        
       console.log("checked1 = " + check1);
        //if (check == true) {
        ////    $(x).prop("checked", true);
        ////    $('input[name=IsChecked]').attr('checked', true);
        //    //    $("#insert-List-Item-Modal input[name='IsChecked']").prop("checked", true).toString();
        //    var check = (check == "true");
        //}
        //else {
        ////    $(x).prop("checked", false);
        ////    $("#insert-List-Item-Modal input[name='IsChecked']").prop("checked", false).toString();
        ////    $('input[name=IsChecked]').attr('checked', false);
        ////    $("#insert-List-Item-Modal input[type='checkbox']").prop('checked', false);
        ////    $("#insert-List-Item-Modal input[type='checkbox']").removeAttr("checked");
        //var check = (check == "false");
        //}
      
        
        console.log("id = " + id);
        console.log("name = " + name);
        console.log("date = " + date);
        console.log("dateto = " + dateto);
        //$("#insert-List-Item-Modal input[name=ToDoListId]").val(id);
        $("#insert-List-Item-Modal input[name=NameOfDuty]").val(name);
        $("#insert-List-Item-Modal input[name=Date]").val(date);
        $("#insert-List-Item-Modal input[name=DateToFinish]").val(dateto);
        $("#insert-List-Item-Modal input[name=IsChecked]").prop('checked', check1);

        $("#insert-List-Item-Modal input[name=ToDoListId]").val(id).prop("disabled", false);

        $("#formid").attr("action", "ToDoList/Edit");
       

    });
};



$(document).ready(function () {
   
    rh.list.attacheventhandler();
    rh.list.enablebuttons();
});



//console.log("hello, world");
//$("#toggle-edit").click(function () {

//    $(".edit-actions").toggleClass("hidden");

//});