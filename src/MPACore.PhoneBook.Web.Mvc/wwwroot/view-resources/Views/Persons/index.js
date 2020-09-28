(function () {

    $(function () {

        var _personService = abp.services.app.person;

        var _$modal = $("#PersonCreateModal");
        var _$form = _$modal.find("form");
        //add start
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
            if (!_$form.valid()) {
                return;
            }

            var personEditDto = _$form.serializeFormToObject();

            personEditDto.PhoneNumbers = [];
            var phoneNumber = {};
            phoneNumber.PhoneType = personEditDto.PhoneNumberType;
            phoneNumber.Number = personEditDto.PhoneNumber;
            personEditDto.PhoneNumbers.push(phoneNumber);

            abp.ui.setBusy(_$modal);

            _personService.createOrUpdatePerson(personEditDto).done(function () {
                _$modal.modal("hide");
                location.reload();
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        $("#RefreshPersonList").click(function () {
            refreshPersonList();
        });
        // add end

        function refreshPersonList() {
            location.reload();
        }
        //delete
        $(".delete-person").click(function () {
            var personId = $(this).attr('data-person-id');
            var personName = $(this).attr('data-person-name');
            deletePerson(personId, personName);
        });

        function deletePerson(id, name) {
            abp.message.confirm("是否确认删除姓名为：【" + name + "】 的联系人", function (isComfirm) {
                if (isComfirm) {
                    _personService.deletePerson({ id }).done(function () {
                        refreshPersonList();
                    });
                }
            });
        }

        //delete end

        //edit
        $(".edit-person").click(function (e) {
            e.preventDefault();
            var personId = $(this).attr("data-person-id");
            _personService.getPersonForEdit({ id: personId }).done(function (data) {
                $("input[name=Id").val(data.person.id);
                $("input[name=Name").val(data.person.name).parent().addClass("focused");
                $("input[name=Email").val(data.person.email).parent().addClass("focused");
                $("input[name=Address").val(data.person.address).parent().addClass("focused");
                $("input[name=PhoneNumber").val(data.person.phoneNumbers[0].number).parent().addClass("focused");
                $("select[name=PhoneNumberType").selectpicker('val', data.person.phoneNumbers[0].PhoneType);
            })
        });

        $("#PersonCreateModal").on("hide.bs.modal", function () {
            _$form[0].reset();
        });
    })
})();