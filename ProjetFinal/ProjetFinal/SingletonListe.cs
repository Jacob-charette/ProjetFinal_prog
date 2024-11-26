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
        ObservableCollection<Categorie> listeCategorie;
        ObservableCollection<Seance> listeSeance;

        static SingletonListe instance = null;

        //ObservableCollection<Equipes> liste;
        // static SingletonListe instance = null;

        public SingletonListe()
        {
            listeAdmin = new ObservableCollection<Administrateur>();
            listeAdherent = new ObservableCollection<Adherent>();
            listeActivite = new ObservableCollection<Activite>();
            listeCategorie = new ObservableCollection<Categorie>();
            listeSeance = new ObservableCollection<Seance>();
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2024_420335ri_eq7;" +
                                                "Uid=1921615;Pwd=1921615;");

            listeAdmin.Clear();
            listeAdherent.Clear();
            listeActivite.Clear();
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
            commande3.CommandText = "Select * from activites";
            con.Open();
            MySqlDataReader r3 = commande3.ExecuteReader();
            while (r3.Read())

            {
                int cout_organisation = Convert.ToInt16(r2[1].ToString());
                int prix_vente = Convert.ToInt16(r2[2].ToString());
                int id_Admin = Convert.ToInt16(r2[3].ToString());
                int id_categorie = Convert.ToInt16(r2[4].ToString());

                listeActivite.Add(new Activite(cout_organisation, prix_vente, id_Admin, id_categorie));

            }
            r2.Close();
            con.Close();
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

}