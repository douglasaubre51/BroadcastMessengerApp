"use strict";

let accountId=document.getElementById('account-id').value;

// create divs for chats
let chatBody = document.createElement("div");
chatBody.setAttribute("id", "chat-body");

let chatContainer = document.createElement("div");
chatContainer.setAttribute("id", "chat-container");
chatContainer.append(chatBody);

let bodyContainer = document.getElementById("body-container");
bodyContainer.append(chatContainer);

// when a channel is clicked!
function getMessages(id) {
  chatBody.innerHTML = "";

  // fetch chats from .net
  fetch("/Tutor/GetMessages?id=" + id)
    .then((response) => response.json())
    .then((data) => {
      for (let d of data) {
        if (d.data.trim() === "") {
        } else {
          let messageBody = document.createElement("h4");
          messageBody.textContent = d.data;
          chatBody.append(messageBody);
        }
      }

      let messageBox = document.createElement("input");
      messageBox.setAttribute("type", "text");
      messageBox.setAttribute("id", "messageBox");
      chatBody.append(messageBox);

      let submitBtn = document.createElement("input");
      submitBtn.setAttribute("type", "button");
      submitBtn.setAttribute("onclick", "sendMessage(" + id + ");");
      submitBtn.setAttribute("value", "send");
      chatBody.append(submitBtn);
    });
}

// when the send btn is clicked!
function sendMessage(id) {
  // play test
  console.log(`time : ${new Date().getHours()}:${new Date().getMinutes()}`);

  // create payload!
  let messageBox = document.getElementById("messageBox");

  const date = new Date();

  const minutes = date.getMinutes();
  let temp=minutes < 10 ? ":0" : ":" + "" + minutes;
  const time = date.getHours() + "" + temp+":"+date.getSeconds()

  // show payload!
  console.log(id);
  console.log(accountId);
  console.log(messageBox.value);
  console.log(
    date.getFullYear() + "-" +(1+ date.getMonth())+ "-" + date.getDate(),
  );
  console.log(time);

  // send payload!
  fetch("/Tutor/SendMessage", {
    method: "POST",

    headers: {
      "Content-Type": "application/json",
    },

    body: JSON.stringify({
      Id: id,
      AccountId:accountId,

      Body: messageBox.value,
      CreatedDate:
        date.getFullYear() + "-" + date.getMonth() + "-" + date.getDate(),
      CreatedTime: time,
    }),
  });
}
