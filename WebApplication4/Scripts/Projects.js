SyntaxHighlighter.all();
    $("#JavaB").click(function () {
        $("#target").fadeToggle("400")
    });
    $('#number').on('shown.bs.modal', function () {
        reset();
        setText();
    });
    $('#number').on('hidden.bs.modal', function () {
        reset();
        setText();
    });
    $('#factorial').on('shown.bs.modal', function () {
        resetF();
    })
    $('#factorial').on('hidden.bs.modal', function () {
        resetF();
    });
    $('#fizzbuzz').on('shown.bs.modal', function () {
        resetFB();
        setTextFB();
    })
    $('#fizzbuzz').on('hidden.bs.modal', function () {
        resetFB();
        setTextFB();
    });
    $('#palindrome').on('shown.bs.modal', function () {
        resetP();
        setTextP();
    })
    $('#palindrome').on('hidden.bs.modal', function () {
        resetP();
        setTextP();
    });