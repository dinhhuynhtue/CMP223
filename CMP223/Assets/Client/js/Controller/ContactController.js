var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var detail = $('#txtdetail').val();

            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    detail: detail
                },
                success: function (res)
                {
                    if (res.status == true)
                    {
                        window.alert('Gửi thành công');
                    }
                }
            });
        });
    }
}
contact.init();

    