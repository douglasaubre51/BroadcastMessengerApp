console.log("im back!")

document.addEventListener("DOMContentLoaded", function () {
    let roleSelector = document.getElementById("selectRole")

    let getRole = document.getElementById("getRole")

    roleSelector.addEventListener("click", function () {
        if (roleSelector.options[roleSelector.selectedIndex].value == 'Admin') {
            alert("u selected admin!")
        }
    })
})
