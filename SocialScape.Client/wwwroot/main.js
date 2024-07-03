window.alertShow = () => {
    console.log("work");
}


//theme
const fontSize = document.querySelectorAll('.choose-size span');
var root = document.querySelector(':root');
const colorPalete = document.querySelectorAll('.choose-color span');



//Fonts
window.changeFontSize = (numberOfSize) => {
    let fontSize;
    if (numberOfSize == 1) {
        fontSize = '10px';
        root.style.setProperty('----sticky-top-left', '5.4rem')
        root.style.setProperty('----sticky-top-right', '5.4rem')
    }
    else if (numberOfSize == 2) {
        fontSize = '13px';
        root.style.setProperty('----sticky-top-left', '5.4rem')
        root.style.setProperty('----sticky-top-right', '-7rem')
    }
    else if (numberOfSize == 3) {
        fontSize = '16px';
        root.style.setProperty('----sticky-top-left', '-2rem')
        root.style.setProperty('----sticky-top-right', '-17rem')
    }
    else if (numberOfSize == 4) {
        fontSize = '19px';
        root.style.setProperty('----sticky-top-left', '-5rem')
        root.style.setProperty('----sticky-top-right', '-25rem')
    }
    else { 
        fontSize = '22px';
        root.style.setProperty('----sticky-top-left', '-12rem')
        root.style.setProperty('----sticky-top-right', '-35rem')
    }

    document.querySelector('html').style.fontSize = fontSize;
}



window.changeColorePalete = (numberOfColor) => {
    let primary;
    if (numberOfColor == 1) {
        primaryHue = 252;
    } else if (numberOfColor == 2) {
        primaryHue = 52;
    } else if (numberOfColor == 3) {
        primaryHue = 352;
    } else if (numberOfColor == 4) {
        primaryHue = 152;
    } else if (numberOfColor == 5) {
        primaryHue = 202;
    }

    root.style.setProperty('--primary-color-hue', primaryHue);
}