$(() => {
    let rowCount = 1;

    $("#add-rows").on('click', function () {
        $("#people-rows").append(`<div class="row" style="margin-bottom: 10px;">
            <div class= "col-md-4" >
                <input class="form-control" type="text" name="people[${rowCount}].firstname" placeholder="First Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${rowCount}].lastname" placeholder="Last Name" />
            </div>
            <div class="col-md-4">
                <input class="form-control" type="text" name="people[${rowCount}].age" placeholder="Age" />
            </div>
        </div>`)
       
        rowCount++;
    })

})