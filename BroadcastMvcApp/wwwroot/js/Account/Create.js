console.log("executing js!");

document.addEventListener("DOMContentLoaded", function () {

    let roleSelector = document.getElementById("selectRole");

    let authorizationRow = document.getElementById("auth-field");
    let departmentRow = document.getElementById("department-dropdown");
    let semesterRow = document.getElementById("semester-dropdown");

    authorizationRow.classList.toggle("hide");
    departmentRow.classList.toggle("hide");
    semesterRow.classList.toggle("hide");

    roleSelector.addEventListener("click", function () {

        let selectedValue = roleSelector[roleSelector.selectedIndex].value;

        console.log("you selected:", selectedValue);

        if (selectedValue == "Tutor") {

            departmentRow.classList.toggle("show");
            authorizationRow.classList.toggle("show");
            semesterRow.classList.toggle("hide");
        }
        else if (selectedValue == "Student") {

            departmentRow.classList.toggle("show");
            semesterRow.classList.toggle("show");
            authorizationRow.classList.toggle("hide");
        }
        else if (selectedValue == "Admin") {

            authorizationRow.classList.toggle("show");
            departmentRow.classList.toggle("hide");
            semesterRow.classList.toggle("hide");
        }
        else if (selectedValue == "select role") {

            departmentRow.classList.toggle("hide");
            semesterRow.classList.toggle("hide");
            authorizationRow.classList.toggle("hide");
        }
    });
});
