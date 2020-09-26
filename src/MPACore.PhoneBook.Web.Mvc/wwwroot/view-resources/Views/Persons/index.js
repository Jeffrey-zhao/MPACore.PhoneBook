(function () {

    $(function () {

        var _personService = abp.services.app.person;

        var _$modal = $("#PersonCreateModal");
        var _$form = _$modal.find("form");

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
            if (!_$form.valid()) {
                return;
            }

            var personEditDto = _$form.serializeFormToObject();
            abp.ui.setBusy(_$modal);

            _personService.createOrUpdatePerson(personEditDto).done(function () {
                _$modal.modal("hide");
                location.reload();
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
    })
})();