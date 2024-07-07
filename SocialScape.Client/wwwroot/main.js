window.alertShow = () => {
    console.log("work");
}


//theme
const fontSize = document.querySelectorAll('.choose-size span');
var root = document.querySelector(':root');
const colorPalete = document.querySelectorAll('.choose-color span');
const bg1 = document.querySelector('.bg-1');
const bg2 = document.querySelector('.bg-2');
const bg3 = document.querySelector('.bg-3');


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



let lightColorLightness;
let whiteColorLightness;
let darkColorLightness;

const changeBG = () => {
    root.style.setProperty('--light-color-lightness', lightColorLightness);
    root.style.setProperty('--white-color-lightness', whiteColorLightness);
    root.style.setProperty('--dark-color-lightness', darkColorLightness);
}

window.changeBackground = (numberOfBackground) => {
    if (numberOfBackground == 1) {
    
        darkColorLightness = '17%';
        whiteColorLightness = '95%';
        lightColorLightness = '100%';
        changeBG();
        
    }else if (numberOfBackground == 2) {
        darkColorLightness = '95%';
        whiteColorLightness = '20%';
        lightColorLightness = '15%';

        
        changeBG();

    } else if (numberOfBackground == 3) {
        darkColorLightness = '95%';
        whiteColorLightness = '10%';
        lightColorLightness = '0%';

        changeBG();
    }
}



//////Authentication//////
const sign_in_btn = document.querySelector("#sign-in-btn");
const sign_up_btn = document.querySelector("#sign-up-btn");
const container = document.querySelector('.container-auth');

window.signUpBtn = () => {
    container.classList.add("sign-up-mode");
} 

window.signInBtn = () => {
    container.classList.add("sign-in-mode");
} 


const stars = document.querySelectorAll("#star");


    stars.forEach((star) => {
        let duration = Math.random() * (1.2 - 0.6) + 0.6;
        console.log(duration);
        star.style.animation = `stars ${duration}s infinite linear`;
    })

   
