/* Projet de programmation répartie */

Minimum à mettre dans les classes (en fonction du screen du prof)

	Général :
		- liste de promotions

	Propriétés d'une promotion :
		- nom
		- année
		- liste d'étudiants

	Propriétés d'un étudiant :
		- prenom
		- nom
		- date de naissance

Lien vers le sujet :
	drive.google.com/file/d/0BxPAOqJIEq52empPX0xZQUIza0U/view

Les exigences de la data (pour la business) :
	Sur la méthode "serialiser_promotion(GestionPromotion.Entity.BC.Promotion p_promotion, String p_chemin_dacces)"
		Vérifier si le chemin d'accès est un fichier .xml ou si c'est un simple chemin sans fichier. Dans le cas où c'est un simple chemin, rajouter promotions.xml à la fin.
		Ne rien faire sur la promo, elle peut être vide !