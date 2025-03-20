document.addEventListener("DOMContentLoaded", function () {
    const chatBody = document.getElementById("chatBody")

    fetch("/Tutor/GetMessages")
        .then(response => response.json())
        .then(data => console.log(data))
        .then(data => {
            let messages = data
            messages.forEach((e) => {
                let chat = document.createElement("div")
                chat.classList.add("chat")
                chat.textContent = e.Data

                chatBody.appendChild(chat)
            })
        })
})







// console.log("message hub!")

// var _conn = new signalR.HubConnectionBuilder()
//     .withUrl("/Hubs/MessageHub")
//     .build()

// document.addEventListener("DOMContentLoaded", function () {
//     _conn.on("sendAMessage", (message) => {
//         var signalRMessage = document.getElementById('signalr-message')

//         signalRMessage.innerHTML = message.toString()
//         alert(message)
//         console.log("given message")
//     })

//     function SendOnClient() {
//         _conn.send("SendAMessage")
//     }

//     function fulfilled() {
//         SendOnClient()
//     }

//     function rejected() {
//         console.log("error connecting to signalr!")
//     }

//     _conn.start().then(fulfilled, rejected)
// })