let features= [
    {
        img: "./resources/img/fortnite resized.jpg",
        title: "Fortnite",
        description: "Some quick example text to build on the card title and make up the bulk of the card's content",
        url: "www.github.com",
    },
    {
        img: "./resources/img/jedi survivor resized.jpg",
        title: "Star Wars: Jedi Survivor",
        description: "Some quick example text to build on the card title and make up the bulk of the card's content",
        url: "www.github.com",
    },
    {
        img: "./resources/img/the last of us resized.jpg",
        title: "The Last of Us: Part 1",
        description: "Some quick example text to build on the card title and make up the bulk of the card's content",
        url: "www.github.com",
    },
    {
        img: "./resources/img/the quarry.jpeg",
        title: "The Quarry",
        description: "Some quick example text to build on the card title and make up the bulk of the card's content",
        url: "www.github.com",
    }
]
let loadFeatures= function(){
    let html = `<div class="row">`
        features.forEach(function(feature){
            html += `
                <div class="card m-4" style="width: 18rem;">
                    <img src="${feature.img}" class="card-img-top" alt="..." width="200" height=125">
                    <div class="card-body">
                        <h5 class="card-title">${feature.title}</h5>
                        <p class="card-text">${feature.description}</p>
                        <a href="${feature.url}" class="btn btn-primary">Go somewhere</a>
                    </div>
                </div>
            `
        })
    html += "</div>"
    document.getElementById("cards").innerHTML = html
}
function handleOnLoad(){
    loadFeatures()
}