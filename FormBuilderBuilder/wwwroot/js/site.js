var ttl = document.getElementById("Title"),
    lbl = document.getElementById("Label");
    pgslg = document.getElementById("PageSlug");
    qstnid = document.getElementById("QuestionID");
    src = document.getElementById("FormName"),
    dst = document.getElementById("BaseURL");



src.addEventListener('input', function () {
    dst.value = src.value.replace(" ", "-").replace(" ", "-").replace(" ", "-").replace(" ", "-").replace(" ", "-").replace(" ", "-").replace(" ", "-").replace(" ", "-");

});

ttl.addEventListener('input', function () {
    lbl.value = ttl.value;
});

pgslg.addEventListener('input', function () {
    qstnid.value = pgslg.value.replace("-", "").replace("-", "").replace("-", "").replace("-", "").replace("-", "").replace("-", "").replace("-", "").replace("-", "").replace("-", "");
});


