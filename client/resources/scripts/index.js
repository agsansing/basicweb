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
    let html = `<div class="container-fluid">`
        features.forEach(function(feature){
            html += `
            <div class="row" style="display: inline-block; margin: 8px; padding: 8px">    
                <div class="card m-4" style="width: 18rem;">
                    <img src="${feature.img}" class="card-img-top" alt="..." width="200" height=125">
                    <div class="card-body">
                        <h5 class="card-title">${feature.title}</h5>
                        <p class="card-text">${feature.description}</p>
                        <a href="${feature.url}" class="btn btn-primary">Go somewhere</a>
                    </div>
                </div>
            </div>
            `
        })
    html += "</div>"
    document.getElementById("cards").innerHTML = html
}
function getGames(){
    const allGamesApiUrl = "https://localhost:7099/api/games";

    fetch(allGamesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<ul>";
        json.forEach((game)=>{
            html += "<li>" + game.title + " " + game.genre + "</li>";
        });
        html += "</ul>";
        document.getElementById("games").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    });
}
function postGame(){
    const postGameApiUrl = "https://localhost:7099/api/games";
    const gameTitle = document.getElementById("title").value;
    const gameGenre = document.getElementById("genre").value;

    fetch(postGameApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            title: gameTitle,
            genre: gameGenre
        })
    })
    .then((response)=>{
        console.log(response);
        getGames();
    })
}
function handleOnLoad(){
    loadFeatures();
    getGames();
}