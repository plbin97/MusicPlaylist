// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const cookieParser = str =>
    str
        .split(';')
        .map(v => v.split('='))
        .reduce((acc, v) => {
            acc[decodeURIComponent(v[0].trim())] = decodeURIComponent(v[1].trim());
            return acc;
        }, {});

let getDataFromUploadInput = (csvUploadInput) => {
    return new Promise((resolve) => {
        csvUploadInput.onchange = () => {
            csvUploadInput.setAttribute("disabled", "");
            let reader = new FileReader();
            reader.onload = () => {
                resolve(reader.result);
            }
            reader.readAsBinaryString(csvUploadInput.files[0]);
        }
    })
}

let uploadCsvDataToServer = (csvString) => {
    return new Promise((resolve) => {
        let xhr = new XMLHttpRequest();
        xhr.onload = () => {
            resolve(xhr.responseText);
        }
        xhr.open("POST", "/api/upload");
        xhr.send(csvString)
    })
}

let setCookie = (token) => {
    let date = new Date();
    let nowTime = date.getTime();
    let expTime = nowTime + (1000 * 3600 * 24 * 30);
    date.setTime(expTime);
    document.cookie = `token=${token}; expires=${date.toUTCString()}; path=/`;
}

indexPageScript = async (redirectURL) => {
    let csvUploadInput = document.getElementById("csvUploadInput");
    let csvData = await getDataFromUploadInput(csvUploadInput);
    let token = await uploadCsvDataToServer(csvData);
    setCookie(token)
    location.href = redirectURL;
}
