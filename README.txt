/* Projet de programmation r�partie */

Minimum � mettre dans les classes (en fonction du screen du prof)

	G�n�ral :
		- liste de promotions

	Propri�t�s d'une promotion :
		- nom
		- ann�e
		- liste d'�tudiants

	Propri�t�s d'un �tudiant :
		- prenom
		- nom
		- date de naissance

Lien vers le sujet :
	drive.google.com/file/d/0BxPAOqJIEq52empPX0xZQUIza0U/view

Les exigences de la data (pour la business) :
	Sur la m�thode "serialiser_promotion(GestionPromotion.Entity.BC.Promotion p_promotion, String p_chemin_dacces)"
		V�rifier si le chemin d'acc�s est un fichier .xml ou si c'est un simple chemin sans fichier. Dans le cas o� c'est un simple chemin, rajouter promotions.xml � la fin.
		Ne rien faire sur la promo, elle peut �tre vide !