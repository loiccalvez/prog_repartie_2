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

Le fonctionnement de la data :
	M�thode serialiser_promotion(1, 2, 3)
		 1. La liste des promotions qui est � sauvegarder dans le fichier .xml
		*2. Le chemin d'acc�s dans lequel il faut d�poser le fichier .xml
		*3. Le nom du fichier qui porte l'extension .xml

Les exigences de la data (pour la business) :
	Sur la m�thode "serialiser_promotion(GestionPromotion.Entity.BC.Promotions p_promotions, String p_chemin_dacces)"
		V�rifier si le chemin d'acc�s est un fichier .xml ou si c'est un simple chemin sans fichier. Dans le cas o� c'est un simple chemin, rajouter promotions.xml � la fin.
		Ne rien faire sur la promo, elle peut �tre vide !