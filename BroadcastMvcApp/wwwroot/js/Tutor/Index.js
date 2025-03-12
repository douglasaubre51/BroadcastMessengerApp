console.log("message hub!")

var _conn = new signalR.HubConnectionBuilder()
    .withUrl("/Hubs/MessageHub")
    .build()

document.addEventListener("DOMContentLoaded", function () {
    _conn.on("sendAMessage", (message) => {
        var signalRMessage = document.getElementById('signalr-message')

        signalRMessage.innerHTML = message.toString()
        alert(message)
        console.log("given message")
    })

    function SendOnClient() {
        _conn.send("SendAMessage")
    }

    function fulfilled() {
        SendOnClient()
    }

    function rejected() {
        console.log("error connecting to signalr!")
    }

    _conn.start().then(fulfilled, rejected)
})