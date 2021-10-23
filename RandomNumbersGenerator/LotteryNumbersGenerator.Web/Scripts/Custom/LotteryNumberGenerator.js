$(function () {
    $(document).on('click', '#btnGenerate', function (e) {
        var sets = $('#txtNumberOfSets').val();
        var lotteryType = $('#ddlLotteryTypes').val();
        
        $.ajax({
            url: $('#url-generateNumbers').val(),
            type: "POST",
            data: { sets: sets, lotteryType: lotteryType }
        }).done(function (result) {
            $('#GeneratedNumbers').html(result);

            var table = document.getElementById('tblGeneratedNumbers');
            var tbody = table.getElementsByTagName('tbody')[0];

            if (tbody == undefined) return;

            var cells = tbody.getElementsByTagName('td');

            for (var i = 0, len = cells.length; i < len; i++) {
                var cellValue = parseInt(cells[i].innerText.trim());
                if (cellValue <= 9) {
                    cells[i].style.backgroundColor = 'red';
                }
                else if (cellValue <= 19) {
                    cells[i].style.backgroundColor = 'lightblue';
                }
                else if (cellValue <= 29) {
                    cells[i].style.backgroundColor = 'green';
                }
                else if (cellValue <= 39) {
                    cells[i].style.backgroundColor = 'orange';
                }
                else if (cellValue <= 49) {
                    cells[i].style.backgroundColor = 'purple';
                }
                else if (cellValue <= 59) {
                    cells[i].style.backgroundColor = 'greenyellow';
                }
            }
        });
    });

    $(document).on('keydown keyup keypress', '#btnGenerate', function (e) {
        e.preventDefault();
        if (e.keyCode == 13) {
            $('#btnGenerate').click();
        }
    });

    $(document).on('click', '#btnGenerateUsingAPI', function () {
        debugger;
        var sets = $('#txtNumberOfSets').val();
        $.ajax({
            url: $('#url-generateNumbersUsingAPI').val(),
            type: "POST",
            data: { sets: sets }
        }).done(function (result) {
            alert(result); //do whatever with the data returned
        });
    });

    $('#btnGenerateUsingAPI').keypress(function (e) {
        if (e.which == 13) {
            $('#btnGenerateUsingAPI').click();
        }
    });
   
});

$(document).ready(function () {
    $(window).keydown(function (event) {
        if (event.keyCode == 13) {
            event.preventDefault();
            return false;
        }
    });
});