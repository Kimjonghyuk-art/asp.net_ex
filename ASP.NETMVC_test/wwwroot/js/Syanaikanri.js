$(document).ready(function () {

    $("#openModal").on('click', function () {

        $("#modal").modal();
    })

    document.getElementById('username').addEventListener('input', function () {
        var input = this;
        
        var datalist = document.getElementById('usernames');
        var selectedOption = Array.from(datalist.options).find(option => option.value === input.value);
        if (selectedOption) {
            document.getElementById('SelectedUserId').value = selectedOption.getAttribute('data-id');
            console.log(selectedOption.getAttribute('data-id'));
        } else {
            document.getElementById('SelectedUserId').value = ''; // 일치하는 항목이 없을 때 숨김 필드 비우기
        }
    });

})