document.addEventListener("DOMContentLoaded", function () {
    var form = document.getElementById("loginForm");
    form.addEventListener('click', function() {
        changeSubmitTarget("loginForm", "../Login/Registration");   
    });
    
});

function changeSubmitTarget(formId, newUrl) {
    var form = document.getElementById(formId);
    //form.target = '_blank';
    var oldAction = form.action;
    form.action = newUrl;
    form.submit();
    form.action = oldAction;
    //form.target = '';
}
