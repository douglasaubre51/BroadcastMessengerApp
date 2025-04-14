function getMessages(id) {
    const chatBody = document.getElementById("chatBody")
    chatBody.innerHTML = ''

    fetch("/Tutor/GetMessages?id=" + id)
        .then(response => response.json())
        .then(data => {
            let chatBody = document.getElementById('chatBody')

            for (let d of data) {
                console.log(d.data)

                if (d.data.trim() === "") { }

                else {
                    let messageBody = document.createElement("h4");
                    messageBody.textContent = d.data

                    chatBody.append(messageBody);
                }
            }

            let messageBox = document.createElement('input')
            messageBox.setAttribute('type', 'text')
            messageBox.setAttribute('id', 'messageBox')
            chatBody.append(messageBox)

            let submitBtn = document.createElement('input')
            submitBtn.setAttribute('type', 'button')
            submitBtn.setAttribute('onclick', 'sendMessage(' + id + ')')
            submitBtn.setAttribute('value', 'send')
            chatBody.append(submitBtn)
        })
}

function sendMessage(id) {
    let messageBox = document.getElementById('messageBox')
    const date = new Date()
    console.log(id)

    fetch('/Tutor/SendMessage', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: this.id,
            data: messageBox.value,
            created_time: date.getTime(),
            created_date: date.getDate()
        })
    })
}
