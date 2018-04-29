############################################################

Loïc Labourbe, 2017-2018
Nomadisme, Jeux et Développement multi-plateformes SOM2IF17

############################################################


########## Principe général

Mon projet est un jeu de tir de type "Space Shooter".
Un vaisseau se déplace dans l'espace et doit se frayer un chemin parmi les astéroïdes.
Le but est d'en détruire le plus possible. Chaque astéroïde détruit rapporte 1 point au joueur.
Le joueur peut tirer des rayons laser à intervalles réguliers. Un seul rayon est nécessaire pour détruire un astéroïde.
Le joueur possède 3 vies, il en perd une chaque fois qu'un astéroïde le percute.

########## Maniabilité

La maniabilité est différente en fonction de la plateforme sur laquelle on joue.

Sur mobile, l'écran est divisé horizontalement en 6 zones. La zone la plus à gauche sert à diriger le vaisseau verticalement.
Si l'utilisateur touche une partie de cette zone plus élevée (resp. basse) que le vaisseau, le vaisseau se dirigera vers le haut (resp. bas).

La zone la plus à droite sert à tirer et à accélérer:
	 	- Pour effectuer un tir, il faut appuyer sur la partie haute de cette zone.
		- Pour accélérer, il faut appuyer sur la partie basse de cette zone.

Pour éviter d'avoir un chevauchement entre le vaisseau et les doigts de l'utilisateur, on interdit au vaisseau de rentrer dans les zones ci-dessus.
Ces zones sont réservées au tactile.

Sur ordinateur, le système de zone n'existe pas. Le vaisseau est libre de se déplacer aux 4 coins de l'écran.
Pour le diriger, il faut utiliser les flèches directionnelles. Pour tirer, il faut appuyer sur la touche espace.


########## Travail effectué	

J'ai implémenté les notions vues dans les 2 TP tels qu'un arrière-plan défilant à l'infini et une gestion du son et du score à l'aide du pattern singleton.

En plus des éléments vus en TP, j'ai enrichi le jeu de tir de différentes manières.

J'ai mis en place une animation pour le vaisseau à l'aide d'un "animator"
L'animation possède 3 états: "vitesse faible ","vitesse moyenne" et "vitesse faible".Les transitions entre ces états se font en fonction de la vitesse du vaisseau.

J'ai amélioré le système de génération des astéroïdes en y ajoutant de l'aléatoire notamment sur leur vitesse, direction et sens de rotation.
De plus, les astéroïdes créés ne peuvent se chevaucher avec un astéroïde déjà existant.
J'ai mis un système de collision très simple en place: quand 2 astéroïdes de vitesse contraires se rencontrent, ils sont repoussés dans une direction opposée.
Ce système marche quand les conditions sont idéales.

J'ai modifié la rotation du vaisseau en fonction de sa vitesse verticale afin de rendre son déplacement plus fluide à l'écran.
La direction des tirs est aussi impactée par la rotation du vaisseau.

J'ai implémenté un système de gestion de point de vie pour les astéroïdes. 
Actuellement les astéroïdes n'ont qu'une seule vie donc le système n'est pas exploité.
Si l'on voulait augmenter leur vie il n'y aurait qu'une seule valeur à modifier dans tout le code.

Pour finir, j'ai utilisé un simulateur de particule pour générer des étoiles en arrière-plan.


########## Test Effectés

J'ai testé le jeu sur mon smartphone LG G3, version 5.0 d'Android.

########## Difficultés rencontrées

J'ai eu du mal à gérer le tactile. Le fait qu'il faille compiler et transmettre l'apk au téléphone induit un grand temps d'attente pour vérifier un simple changement de valeur d'une variable.
J'ai aussi eu du mal à décider de la jouabilité du jeu en version tactile. Je pense que la maniabilité est acceptable mais je en suis pas totalement satisfait du système d'accélération mis en place.

########## Remarques

J'ai bien aimé faire ce projet mais je trouve dommage que le coefficient de la matière ne soit que de 1.
Pour vous donner une idée, l'Anglais à un coefficient de 2 et nos autres cours ont un coefficient de 4.






