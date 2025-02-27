document.addEventListener('DOMContentLoaded', function () {
    let addBtn = document.getElementsByClassName('add-btn')

    for (let i = 0; i < addBtn.length; i++) {
        addBtn[i].addEventListener('click', function () {
            let addChannelList = document.getElementsByClassName('add-channel-list')

            if (!(addChannelList[i].textContent.trim() === "")) {
                addChannelList[i].classList.toggle('show')
            }
        })
    }

    let removeBtn = document.getElementsByClassName('remove-btn')

    for (let i = 0; i < removeBtn.length; i++) {
        removeBtn[i].addEventListener('click', function () {
            let removeChannelList = document.getElementsByClassName('remove-channel-list')

            if (!(removeChannelList[i].textContent.trim() === "")) {
                removeChannelList[i].classList.toggle('show')
            }
        })
    }
})