# Ceci n'est pas un jeu mais une démonstration technique

**Ce README contient la liste des différentes fonctions possibles ainsi que le Roadmap (fonctions que j'envisage dans le futur)**
*Note: Il se peut que j'emploi le terme "jeu" car cela me semble plus naturel*

1. **Les déplacements de bases:**
   - Avancer
   - Reculer
   - Gauche
   - Droite
   - Courir
   - S'accroupir
   - **~~Les contrôles peuvent se retrouvé inverser pour X raison (bug à corriger)~~**
   - **Compatibilité AZERTY/QWERTY**
   - **~~Saut et course simultanée possible mais limité~~**
   - **~~Les contrôles sont affichés sur l'écran pendant que l'on joue~~ Ils sont affichés dans la section "controls" du menu pause**

2. **Réaparition au point de départ lors d'un accident de chut dans le vide (Respawn)**

3. **Menu d'accueil et menu pause**
   - Le menu d'accueil:
     - Démarrer la jeu
     - Accéder aux paramètres du jeu
     - Quitter le jeu
     - **~~Les paramètres ne propose que le changement du volume du jeu, il est enregistré donc pas besoin de le changer à chaque lancement~~ Maintenant on peut modifier la résolution, les graphismes (bas, moyen, élévée), choisir si l'on veut en plein écran ou pas, la barre de son à été "optimisé"**

   - Le menu pause:
     - Reprendre le jeu
     - (V2) Contrôles
     - Accéder au menu
     - Quitter le jeu

4. **Ajout de musique**
   - Une musique pour le fond du jeu et une musique pour le menu d'accueil et celui de pause
   - les musique utilisés sont:

   [Cartoon - On & On (feat. Daniel Levi) [NCS Release]](https://www.youtube.com/watch?v=K4DyBUG242c&ab_channel=NoCopyrightSounds) - Fond de jeu

   [Egzod & Maestro Chives - Royalty (ft. Neoni) [NCS Release]](https://www.youtube.com/watch?v=C5fLxtJH2Qs&ab_channel=NoCopyrightSounds) - Menu Accueil et menu pause

5. **Ennemies**
   - Les ennemies ont 100 PV (Point de Vie)
   - les coups de l'arme blanche varie entre 1 et 20 point de dégats sur l'ennemies, le nombre de dégâts est affichés au dessus de l'ennemi
   - Une bar de vie indique combien il reste de vie à l'ennemi.
   - Une fois qu'il atteind 0 PV ou moins il disparait
   - Un son est émis lorsqu'on donne un coup et dès qu'il meurt
   - (V2) Ils apparaisent via un spawner
   - Ils poursuivent le joueur et tire une fois en face de celui-ci
   - Leurs pistolets ont des valeurs aléatoires comme le fusil du joueur, cependant la distance de tir et les dégâts sont réduis (entre 1 et 5 PV par tir)
   - **~~Pour le moment la seul arme utilisable par le joueur pour tuer l'ennemi est un couteau~~**

6. **(V2) Ajout d'un fusil**
   - Il est automatique
   - chaque tir ont:
     - des dégats entre 1 et 10PV
     - une portée entre 1 et 100
     - une puissance de force entre 1 et 30
   - Il peut contenir 30 munitions et se recharge automatiquement, une touche "R" est assignée au rechargement si l'on souhaite rechargé en plein milieu de chargeur (il faut utiliser une munition afin de recharger manuellement, le chargeur à 30 balles alors il en faut 29 pour appuyer sur R).
   - l'affichage des munitions actuelles est visible

7. **(V2) Holster d'armes**
   - Il peut contenir autant d'arme que l'on souhaite et il fonctionne avec la molette de la souris
   - Les touches 1,2,3,4 du clavier (celles du haut) peuvent accéder aux différentes armes directement.

8. **(V2) Barre de vie**
   - Une barre de vie est intégrée au jeu, elle est verte, puis jaune à partir de 40% et lorsqu'on atteind les 20% elle devient rouge
   - dans le même thème: un effet "touché" est appliqué au joueur lorsqu'il est touché par l'ennemi

**(corrigé)**
~~**BUG**
Lorsque le joueur décide de retourner au menu puis de refaire une partie il se peut être retrouvé bloqué, il suffit d'appuyer sur échap et le gameplay continue.~~

## Futur fonction

Pour le moment je me suis contenté de ça en guise de démo technique mais je verrais bien des améliorations eventuelles (tout dépendra de ma motivation), voici ma roadmap:

- [ ] 1. **Extension du niveau**
Le niveau est unique un carré entouré de mur en brique rouge avec une croix rouge en guise de respawn ainsi qu'une structure pour testé la fonction d'accroupissement. Je pense qu'une extension ne fera pas de mal avec + de structure pour embellir le décor.

- [ ] 2. **Accentuation du fond de jeu**
Je me suis contenté de la base, c'est-à-dire le fond bleu et l'éclairage de base mais peut-être qu'un meilleur fond et un meilleur éclairage pourrait amennée du "réalisme" (j'avais un autre mot mais je l'es oublié).

- [x] 3. **Ajout d'armes**
Pour le moment il n'y as qu'un couteau mais je compte ajouté un fusil avec son interface (affichage des munitions, effets spéciaux lorsqu'on tire et qu'on touche), ensuite avec cela un système pour passer d'une arme à une autre et eventuellement une fonction qui permettrerais de donné un coup de couteau lorsqu'on est équippé du fusil.

- [ ] 4. **Meilleurs ennemies**
Les ennemies pour le moment sont statiques et ne se déplacent pas, cependant je compte les faire déplacer et se diriger vers le joueur et ainsi nous attaqué, cela amennera une bar de vie pour le joueur en suppléments.

- [x] 5. **Réparations des différends bugs et eventuelle optimisations**
Notamment le bug d'inversion de contrôles et celui du freeze.

- [x]  6. **Ajouts de paramètres et meilleurs Menu**
Pour le moment les menus sont laids et basiques, je vais les embellir et ajoutés plus de paramètres, notamment une fonctions de respawn des ennemies puis des paramètres graghiques.

## Disclaimer

Tout code utilisé pour ma démonstration technique ne sont que des bouts de codes récupérés sur internet et sur des tutoriel Youtube.
