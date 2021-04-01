## NBA API
<p align="center">
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="30" />
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="30"/>
<img alt="MySQL" width="30px" src="https://raw.githubusercontent.com/github/explore/80688e429a7d4ef2fca1e82350fe8e3517d3494d/topics/mysql/mysql.png" /> 
</p>

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

### NBA Teams
Access information on Official NBA Teams.

#### HTTP Request
```
GET /api/teams
POST /api/teams
GET /api/teams/{id}
PUT /api/teams/{id}
DELETE /api/teams/{id}
```

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| TeamName | string | none | true | Return matches by Team Name.
| Location | string | none | true | Return any NBA Teams in a certain Location/City.
| NbaTeamsChampionships | int | none | true | Return NBA Teams with specific number of NBA Championships in their franchise. |

#### Example Query
```
https://localhost:5000/api/teams/?location=toronto&NbaTeamsChampionships=1
```

#### Sample JSON Response
```
{
    "TeamId": 28,
    "TeamName": "Raptors",
    "Location": "Toronto",
    "NbaTeamsChampionships: 1,
    "Players": [
        {
            "PlayerId": 5,
            "PlayerName": "Kyle Lowry",
            "Position": "Point Guard",
            "JerseyNumber": 7,
            "NbaPlayersChampionships": 1,
            "PlayOffs": 10,
            "AllStars": 5,
            "TeamId": 28,
            "Team": "Raptors"
        }
    ]

}
```
</details>
<details>
<summary>Players</summary>

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