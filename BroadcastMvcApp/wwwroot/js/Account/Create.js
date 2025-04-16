console.log("executing js!");

document.addEventListener("DOMContentLoaded", function () {
  let roleSelector = document.getElementById("selectRole");

  roleSelector.addEventListener("click", function () {
    let selectedValue = roleSelector[roleSelector.selectedIndex].value;

    console.log("you selected:", selectedValue);

    let authorizationRow = document.getElementById("authorization-id");
    let departmentRow = document.getElementById("department-id");
    let semesterRow = document.getElementById("semester-id");

    if (selectedValue == "Tutor") {
      departmentRow.classList.add("show-department");
      authorizationRow.classList.add("show-authorization");

      semesterRow.classList.remove("show-semester");
    } else if (selectedValue == "Student") {
      departmentRow.classList.add("show-department");
      semesterRow.classList.add("show-semester");

      authorizationRow.classList.remove("show-authorization");
    } else if (selectedValue == "Admin") {
      authorizationRow.classList.add("show-authorization");

      departmentRow.classList.remove("show-department");
      semesterRow.classList.remove("show-semester");
    } else if (selectedValue == "select role") {
      departmentRow.classList.remove("show-department");
      semesterRow.classList.remove("show-semester");
      authorizationRow.classList.remove("show-authorization");
    }
  });
});
