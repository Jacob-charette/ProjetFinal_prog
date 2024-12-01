﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinal
{
    internal class SingletonListe
    {
        static SingletonListe instance = null;

        public static SingletonListe getInstance()
        {

            if (instance == null)
                instance = new SingletonListe();

            return instance;

        }

        MySqlConnection con;
        ObservableCollection<Administrateur> listeAdmin;
        ObservableCollection<Adherent> listeAdherent;
        ObservableCollection<Activite> listeActivite;
        ObservableCollection<Activite> listeActivite2;
        ObservableCollection<Categorie> listeCategorie;
        ObservableCollection<Seance> listeSeance;
        ObservableCollection<Seance> listeActiviteId;
        

        //ObservableCollection<Equipes> liste;
        // static SingletonListe instance = null;

        public SingletonListe()
        {
            listeAdmin = new ObservableCollection<Administrateur>();
            listeAdherent = new ObservableCollection<Adherent>();
            listeActivite = new ObservableCollection<Activite>();
            listeActivite2 = new ObservableCollection<Activite>();
            listeActiviteId = new ObservableCollection<Seance>();
            listeCategorie = new ObservableCollection<Categorie>();
            listeSeance = new ObservableCollection<Seance>();
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq7;" +
                                                "Uid=1921615;Pwd=1921615;");

            listeAdmin.Clear();
            listeAdherent.Clear();
            listeActivite.Clear();
            listeActivite2.Clear();
            listeActiviteId.Clear();
            listeCategorie.Clear();
            listeSeance.Clear();

            //Liste pour administrateur
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from administrateur";
            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {
                string password = r[0].ToString();
                string nom_utilisateur = r[1].ToString();


                listeAdmin.Add(new Administrateur(password, nom_utilisateur));
            }
            r.Close();
            con.Close();

            //Liste pour Categorie
            MySqlCommand commande2 = new MySqlCommand();
            commande2.Connection = con;
            commande2.CommandText = "Select * from categories";
            con.Open();
            MySqlDataReader r2 = commande2.ExecuteReader();
            while (r2.Read())

            {

                string nom = r2[1].ToString();
                string image = r2[3].ToString();
                int id_Admin = Convert.ToInt16(r2[2].ToString());

                listeCategorie.Add(new Categorie(nom, id_Admin, image));

            }
            r2.Close();
            con.Close();

            //Liste pour activite
            MySqlCommand commande3 = new MySqlCommand();
            commande3.Connection = con;
            commande3.CommandText = "Select id_Activite,cout_organisation,prix_vente,c.id_Admin,c.id_categorie,c.image,nom from activites " +
                                        " inner join categories c on activites.id_categorie = c.id_categorie group by image";
            con.Open();
            MySqlDataReader r3 = commande3.ExecuteReader();
            while (r3.Read())

            {
                int id_Activite = Convert.ToInt16(r3[0].ToString());
                int cout_organisation = Convert.ToInt16(r3[1].ToString());
                int prix_vente = Convert.ToInt16(r3[2].ToString());
                int id_Admin = Convert.ToInt16(r3[3].ToString());
                int id_categorie = Convert.ToInt16(r3[4].ToString());
                string image = r3[5].ToString();
                string nom = r3[6].ToString();
               

                listeActivite.Add(new Activite(id_Activite, cout_organisation, prix_vente, id_Admin, id_categorie, image, nom));

            }
            r3.Close();
            con.Close();

            //Liste pour adherent
            MySqlCommand commande4 = new MySqlCommand();
            commande4.Connection = con;
            commande4.CommandText = "Select * from adherents";
            con.Open();
            MySqlDataReader r4 = commande4.ExecuteReader();
            while (r4.Read())

            {
                string id_Adherent = r4[0].ToString();
                string nom = r4[1].ToString();
                string prenom = r4[2].ToString();
                string adresse = r4[3].ToString();
                string date_naissance = r4[4].ToString();
                int age = Convert.ToInt16(r4[5].ToString());
                int id_Admin = Convert.ToInt16(r4[6].ToString());

                listeAdherent.Add(new Adherent(id_Adherent, nom, prenom, adresse, date_naissance,age,id_Admin));

            }
            r4.Close();
            con.Close();

            //Liste pour seance
            MySqlCommand commande5 = new MySqlCommand();
            commande5.Connection = con;
            commande5.CommandText = "Select * from seances";
            con.Open();
            MySqlDataReader r5 = commande5.ExecuteReader();
            while (r5.Read())

            {
                string date_organisation = r5[1].ToString();
                string heure_organisation = r5[2].ToString();
                int nbr_place_disponible = Convert.ToInt16(r5[3].ToString());
                int note_appreciation = Convert.ToInt16(r5[4].ToString());
                int id_Admin = Convert.ToInt16(r5[5].ToString());
                int id_Activite = Convert.ToInt16(r5[6].ToString());
                string id_Adherent = r5[7].ToString();

                listeSeance.Add(new Seance(date_organisation, heure_organisation, nbr_place_disponible, note_appreciation, id_Admin, id_Activite, id_Adherent));

            }
            r5.Close();
            con.Close();

            //Liste pour activite et adhérent
            MySqlCommand commande7 = new MySqlCommand();
            commande7.Connection = con;
            commande7.CommandText =     "SELECT c.nom AS Activite, COUNT(DISTINCT asn.id_Adherent) AS Nombre_Adherents " +
                                        "from activites a " +
                                        "JOIN seances s ON a.id_Activite = s.id_Activite " +
                                        "JOIN adherent_seance asn ON s.id_seance = asn.id_seance " +
                                        "JOIN categories c ON a.id_categorie = c.id_categorie " +
                                        "GROUP BY c.nom;";
            con.Open();
            MySqlDataReader r7 = commande7.ExecuteReader();
            while (r7.Read())
            {
                string nomActivite = r7["Activite"].ToString();
                int nombreAdherents = Convert.ToInt32(r7["Nombre_Adherents"]);

                listeActivite2.Add(new Activite(nomActivite, nombreAdherents));
            }
            r7.Close();
            con.Close();
        }
            public ObservableCollection<Activite> ListeActivite { get { return listeActivite; } }
            public ObservableCollection<Activite> ListeActivite2 { get { return listeActivite2; } }

        public ObservableCollection<Seance> getIdActivite(int _id_activite)
        {
            ObservableCollection<Seance> filteredSeances = new ObservableCollection<Seance>();

            //Liste pour Seance
            MySqlCommand commande6 = new MySqlCommand();
            commande6.Connection = con;
            commande6.CommandText = $"Select * from seances where id_Activite = {_id_activite} AND nbr_place_disponible > 0";
            con.Open();
            MySqlDataReader r6 = commande6.ExecuteReader();
            while (r6.Read())
            {
                string date_organisation = r6[1].ToString();
                string heure_organisation = r6[2].ToString();
                int nbr_place_disponible = Convert.ToInt16(r6[3].ToString());
                int note_appreciation = Convert.ToInt16(r6[4].ToString());
                int id_Admin = Convert.ToInt16(r6[5].ToString());
                int id_Activite = Convert.ToInt16(r6[6].ToString());
                string id_Adherent = r6[7].ToString();

                filteredSeances.Add(new Seance(date_organisation, heure_organisation, nbr_place_disponible, note_appreciation, id_Admin, id_Activite, id_Adherent));

            }
            r6.Close();
            con.Close();
            return filteredSeances;
        }
    }



    /*  public void initialiseliste()
      {

          liste.Clear();
          MySqlCommand commande = new MySqlCommand();
          commande.Connection = con;
          commande.CommandText = "Select * from equipe";
          con.Open();
          MySqlDataReader r = commande.ExecuteReader();
          while (r.Read())


          {
              string nom = r[0].ToString();
              string ville = r[1].ToString();
              string logo = r[2].ToString();
              liste.Add(new Equipes(nom, ville, logo));

          }
          r.Close();
          con.Close();

      }
      public void initialiseliste2()
      {

          liste2 = new ObservableCollection<Joueurs>();
          liste2.Clear();
          MySqlCommand commande2 = new MySqlCommand();
          commande2.Connection = con;
          commande2.CommandText = "Select * from joueur";
          con.Open();
          MySqlDataReader r2 = commande2.ExecuteReader();
          while (r2.Read())

          {

              string maricule = r2[0].ToString();
              string nom = r2[1].ToString();
              string prenom = r2[2].ToString();
              string date_naissance = r2[3].ToString();
              string team = r2[4].ToString();



              liste2.Add(new Joueurs(maricule, nom, prenom, date_naissance, team));

          }
          r2.Close();
          con.Close();


      }


      public ObservableCollection<Equipes> Liste { get { return liste; } }
      public ObservableCollection<Joueurs> Liste2 { get { return liste2; } }
      public void ajouter(string nom, string ville, string logo)
      {

          string nom2 = nom;
          string ville2 = ville;
          string logo2 = logo;
          try
          {
              MySqlCommand commande = new MySqlCommand();
              commande.Connection = con;
              commande.CommandText = $"insert into equipe values('{nom2}','{ville2}','{logo2}')";

              con.Open();
              commande.ExecuteNonQuery();

              con.Close();
          }
          catch (Exception ex)
          {
              con.Close();
          }
          initialiseliste();

      }
      public void ajouter2(string nom, string prenom, string date)
      {
          string nom2 = nom.Substring(0, 1);
          string prenom2 = prenom.Substring(0, 1);
          int chiffre = new Random().Next(1000);
          string matricule2 = nom2 + prenom2 + chiffre;

          string date2 = date;
          bool verification = true;

          do
          {
              MySqlCommand commande2 = new MySqlCommand();
              commande2.Connection = con;
              commande2.CommandText = "Select * from joueur";
              con.Open();
              MySqlDataReader r2 = commande2.ExecuteReader();
              while (r2.Read())

              {
                  string maricule = r2[0].ToString();
                  if (maricule == matricule2)
                  {
                      verification = false;
                      chiffre = new Random().Next(1000);
                      matricule2 = nom2 + prenom2 + chiffre;
                  }
                  else
                      verification = true;

              }
              r2.Close();
              con.Close();

          } while (verification != true);

          try
          {
              MySqlCommand commande = new MySqlCommand();

              commande.Connection = con;
              commande.CommandText = $"insert into joueur values('{matricule2}','{nom}','{prenom}','{date2}','{date2}')";

              con.Open();
              commande.ExecuteNonQuery();

              con.Close();
          }
          catch (Exception ex)
          {
              con.Close();
          }

          liste2.Clear();
          MySqlCommand commande3 = new MySqlCommand();
          commande3.Connection = con;
          commande3.CommandText = "Select * from joueur";
          con.Open();
          MySqlDataReader r3 = commande3.ExecuteReader();
          while (r3.Read())

          {

              string maricule = r3[0].ToString();
              string nom3 = r3[1].ToString();

              string prenom3 = r3[2].ToString();
              string date_naissance = r3[3].ToString();
              liste2.Add(new Joueurs(maricule, nom3, prenom3, date_naissance, "gf"));
          }
          r3.Close();
          con.Close();


      }
      public void modifier(int index, string nom, string ville, string logo)
      {

      }
      public void recherche(string town)
      {
          initialiseliste();
      }
      public void supprimer(int index)
      {
          try
          {
              MySqlCommand commande = new MySqlCommand();
              Equipes equipes = liste[index];
              string nomEquipes = equipes.Nom;
              commande.Connection = con;
              commande.CommandText = $"delete from equipe where nom ='{nomEquipes}' ";

              con.Open();
              commande.ExecuteNonQuery();

              con.Close();


              liste.Clear();
              MySqlCommand commande1 = new MySqlCommand();
              commande1.Connection = con;
              commande1.CommandText = "Select * from equipe";
              con.Open();
              MySqlDataReader r = commande1.ExecuteReader();
              while (r.Read())

              {
                  string nom = r[0].ToString();

                  string ville = r[1].ToString();

                  string logo = r[2].ToString();


                  liste.Add(new Equipes(nom, ville, logo));
              }
              r.Close();
              con.Close();

          }
          catch (Exception ex)
          {
              con.Close();
          }

      }
      public void supprimer2(int index)
      {
          try
          {
              MySqlCommand commande = new MySqlCommand();
              Joueurs equipe = liste2[index];
              string matPlayer = equipe.Matricule;
              commande.Connection = con;
              commande.CommandText = $"delete from joueur where matricule ='{matPlayer}' ";

              con.Open();
              commande.ExecuteNonQuery();

              con.Close();
          }
          catch (Exception ex)
          {
              con.Close();
          }

          initialiseliste2();


      }
      public int index(Equipes a)
      {

          int index = 0;
          //index = Liste.IndexOf(a);
          return index;
      }
      //public Equipes getArticle(int position)
      //{
      //    //return liste[position];
      //}
  }*/
}

