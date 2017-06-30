function createTemplate(form, path) {
    var service = new ItemService({ url: '/sitecore/api/ssc/item' });
    var obj = {
        ItemName: 'comment - ' + form.name.value,
        TemplateID: '{C6FAFBD2-CD02-4A59-8F92-CBD2C70BA1E9}',
        Name: form.name.value,
        Comment: form.comment.value
    }
    service.create(obj)
    .path(path)
    .execute()
    .then(function (item) {
        form.name.value = form.comment.value = '';
        window.alert("Thanks. Your message will appear on the site shortly");
    })
    .fail(function (err) { window.alert(err); });

    event.preventDefault();
    return false;
}