console.log("js alive");

let isAddChannelListShown = false;
let isRemoveChannelListShown = false;

document.addEventListener("DOMContentLoaded", function () {
  console.log("js DOMContentLoaded!");

  let addBtn = document.getElementsByClassName("add-btn");

  for (let i = 0; i < addBtn.length; i++) {
    addBtn[i].addEventListener("click", function () {
      console.log("click !");
      let addChannelList = document.getElementsByClassName("add-channel-list");

      if (!(addChannelList[i].textContent.trim() === "")) {
        if (isRemoveChannelListShown == false) {
          isAddChannelListShown =
            addChannelList[i].classList.toggle("show-add");
          console.log("is add shown : " + isAddChannelListShown);
        }
      }
    });
  }

  let removeBtn = document.getElementsByClassName("remove-btn");

  for (let i = 0; i < removeBtn.length; i++) {
    removeBtn[i].addEventListener("click", function () {
      console.log("click !");

      let removeChannelList = document.getElementsByClassName(
        "remove-channel-list",
      );

      if (!(removeChannelList[i].textContent.trim() === "")) {
        if (isAddChannelListShown == false) {
          isRemoveChannelListShown =
            removeChannelList[i].classList.toggle("show-remove");
          console.log("is remove shown : " + isRemoveChannelListShown);
        }
      }
    });
  }
});
