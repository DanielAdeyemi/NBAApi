## NBA API

### Specs
#### HTTP Request
Model can be teams or players
```
GET /api/{Model}
GET /api/{Model}/{id}
POST /api/{Model}
PUT /api/{Model}/{id}
DELETE /api/{Model}/{id}
```
#### Example Query
```
https://localhost:5000/api/teams/1
```

#### Sample JSON Response
```
{
    "TeamId": 1,
    "TeamName": "Hawks",
    "Location": "Atlanta",
    "NbaTeamsChampionships: 7,
    "Players": [
        {
            "PlayerId": 1,
            "PlayerName": "Test Testovich",
            "Position": "Forward",
            "JerseyNumber": 5,
            "NbaPlayersChampionships": 0,
            "PlayOffs": 0,
            "AllStars": 0,
            "TeamId": 1,
            "Team": "Hawks"
        }
    ]

}
```

<endpoint>Endpoints
<details>
<summary>Teams</summary>

</details>
<details>
<summary>Teams</summary>

</details>
</endpoint>



User stories:
- as user I want to go GET and POST all the teams in the league
- as user I want to GET and POST all current NBA players (one to many to specific team)
- as user I want to GET all players in specific team
- as user I want to PUT and DELETE players from the team 
- as user I want to PUT a Team
- as user I want to DELETE a team and all players go to FA


<!-- {
        "teamName": "Test",
        "location": "Earth",
        "nbaTeamsChampionships": 0,
        "players": []
    }
        {
        "playerName": "Test Testovich",
        "position": "Forward",
        "jerseyNumber": 5,
        "nbaPlayersChampionships": 0,
        "playOffs": 0,
        "allStars": 0
    } -->