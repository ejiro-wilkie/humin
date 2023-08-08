function HuminAlert() {
    const toast = window.Swal.mixin({
        toast: true,
        position: "bottom-end",
        showConfirmButton: false,
        timer: 3000,
        timerProgressBar: true,
        onOpen: (toast) => {
            toast.addEventListener("mouseenter", window.Swal.stopTimer);
            toast.addEventListener("mouseleave", window.Swal.resumeTimer);
        }
    });

    this.success = function(message) {
        window.Swal.fire(
            "Done!",
            message,
            "success"
        );
    };

    this.error = function(message) {
        window.Swal.fire(
            "Error!",
            message,
            "error"
        );
    };

    this.successToast = function(message) {
        toast.fire({
            icon: "success",
            title: message
        });
    };

    this.errorToast = function(message) {
        toast.fire({
            icon: "error",
            title: message
        });
    };
};

var huminAlert = new HuminAlert();
