# \# VVV? - Projecte Unity 2D

# 

# \## Descripció del joc

# Aquest projecte és una adaptació del videojoc \*\*VVVVVV\*\* desenvolupada amb Unity 2D. 

# 

# \* \*\*Gènere:\*\* Plataformes 2D / Puzle i habilitat.

# \* \*\*Visualització:\*\* Perspectiva lateral en 2D amb fons dinàmic amb efecte \*\*Parallax\*\*.

# \* \*\*Mecànica principal:\*\* A diferència dels jocs de plataformes convencionals, el personatge no salta, sinó que inverteix la seva pròpia gravetat per caminar tant pel terra com pel sostre i superar els diferents obstacles.

# 

# \---

# 

# \## Instruccions i Controls

# L'objectiu del joc és superar els 4 nivells consecutius sense tocar els obstacles ni els enemics fins arribar a la pantalla de victòria.

# 

# \* \*\*Moure's a l'esquerra:\*\* `A` o `Fletxa Esquerra`

# \* \*\*Moure's a la dreta:\*\* `D` o `Fletxa Dreta`

# \* \*\*Invertir la gravetat:\*\* `Espai`

# \* \*\*Pausar la partida:\*\* Botó de pausa situat a la cantonada superior dreta de la pantalla.

# 

# \---

# 

# \## Estructura dels Nivells

# El joc compta amb 4 escenaris jugables amb dificultat progressiva i fons amb efecte Parallax:

# 

# 1\. \*\*Nivell 1 (`LevelOne`):\*\* Escenari d'introducció on el jugador s'ha de desplaçar en un sentit per completar el recorregut.

# 2\. \*\*Nivell 2 (`LevelTwo`):\*\* Introdueix la mecànica d'inversió de gravetat juntament amb elements mortals que eliminen el personatge al contacte.

# 3\. \*\*Nivell 3 (`LevelThree`):\*\* El jugador ha de combinar el canvi de gravetat i el canvi de sentit per avançar i superar l'escenari.

# 4\. \*\*Nivell 4 (`LevelFour`):\*\* Incorpora un enemic que patrulla horitzontalment per una zona caminable (girant automàticament en xocar contra les parets) i que elimina el jugador si hi entra en contacte.

# 

# \---

# 

# \## Interfície d'Usuari (UI)

# \* \*\*Menú d'Inici (`MenuInicial`):\*\* Pantalla principal amb fons, títol del joc, botó per iniciar la partida i botó per sortir de l'aplicació.

# \* \*\*Menú de Pausa:\*\* Accessible des de qualsevol nivell mitjançant el botó superior dret. Atura el temps del joc i permet continuar la partida, reiniciar des de zero o sortir.

# \* \*\*Menú de Mort (`MenuMuerte`):\*\* Apareix quan el personatge és eliminat i permet reintentar l'últim nivell jugat, tornar a començar o sortir.

# \* \*\*Menú de Victòria (`MenuVictoria`):\*\* Pantalla final que felicita el jugador en completar els 4 nivells i ofereix tornar a jugar o sortir del joc.

# \* \*\*Diàleg de proximitat:\*\* Sistema de text integrat a l'escena que s'activa automàticament quan el personatge s'apropa a un element específic sense necessitat de col·lidir-hi.

# 

# \---

# 

# \## So i Arquitectura d'Events

# \* \*\*Música i efectes:\*\* El joc inclou una pista de música de fons que sona en bucle de manera contínua entre escenes i 3 efectes de so independents que s'activen durant la partida.

# \* \*\*Programació basada en events:\*\* La reproducció dels efectes de so està desacoblada de la lògica del joc mitjançant una classe estàtica d'events (`GameEvents`) a la qual se subscriu el gestor d'àudio (`MusicManager`).

# 

# \---

# 

# \## Scripts Principals

# \* `SceneController.cs`: Controla la navegació entre escenes i emmagatzema l'índex de l'últim nivell per permetre'n el reinici.

# \* `PausaController.cs`: Gestiona l'obertura del panell de pausa i el control de `Time.timeScale`.

# \* `MusicManager.cs` i `GameEvents.cs`: Gestionen la música persistent entre nivells i l'execució dels efectes de so mitjançant events.

# \* `EnemyController.cs`: Controla el moviment lateral de l'enemic, la detecció de col·lisions amb parets per canviar de sentit i l'eliminació del jugador.

