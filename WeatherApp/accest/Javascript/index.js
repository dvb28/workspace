const $ = document.querySelector.bind(document);
const $$ = document.querySelectorAll.bind(document);
//các biến
const container  = $('.container');
const cityName = $('.weather__title--name');
const cityStatus = $('.weather__title--status');
const weatherDegC = $('.weather__temperature--deg');
const weatherDegMin = $('.weather__temperature--degD');
const weatherDegMax = $('.weather__temperature--degF');
const weatherImg = $('.weather__img img')
const wind = $('.wind');
const humidity  = $('.humidity');
const pressure = $('.pressure');
const search = $('input');
//Code
var app = {
    getDataAPI: function(cityName) {
        let weatherAPI = `https://api.openweathermap.org/data/2.5/weather?q=${cityName}&appid=75b64dce746f0911d657e772b87a9b95`;
        //Promise
        let promise = new Promise(function(resolve, reject) {
            fetch(weatherAPI)
            .then(function(response) {
                return response.json();
            })
            .then(function(data) {
                resolve(data);
            })
            .catch(function() {
                reject();
            });
        })
        //Use Promise
        promise
            .then(function(data) {
                container.classList.remove('hide');
                app.fillData(data);
                console.log(data)
            })
            .catch(function() {
                container.classList.add('hide');
            })
    },
    fillData: function(data) {
        cityName.innerText = data.name;
        cityStatus.innerText = data.weather[0].main;
        weatherDegC.innerText = Math.floor((data.main.temp - 273.15));
        weatherDegMin.innerText = Math.floor((data.main.temp_min - 273.15  - 10));
        weatherDegMax.innerText = Math.floor((data.main.temp_max - 273.15));
        humidity.innerText = data.main.humidity + '%';
        pressure.innerText = data.main.pressure;
        wind.innerText = data.wind.speed + ' km/h'
        if(weatherDegC.innerText < 34 && weatherDegC.innerText > 17) {
            weatherImg.setAttribute('src', './accest/Img/Cloud.jpg');
        } else if(weatherDegC.innerText < 18) {
            weatherImg.setAttribute('src', './accest/Img/Rain.jpg');
        } else {
            weatherImg.setAttribute('src', './accest/Img/Sunny.jpg');
        }
    },
    searchCity: function() {
        search.addEventListener("keypress", function(e) {
            if(e.code === 'Enter') {
                app.getDataAPI(search.value.trim());
            }
        })
    },
    start: function() {
        this.getDataAPI('ha noi');
        this.searchCity();
    }
}
app.start();
