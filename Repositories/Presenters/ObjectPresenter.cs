﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using Npgsql;

namespace Repositories
{
    public class ObjectPresenter
    {
        DataGridView dgv;
        IObjectRepository objectRepository;
        IPersonRepository ownerRepository;
        List<Entity> dgvElements;

        public ObjectPresenter(DataGridView dgv, IRepositoryFactory repositoryFactory)
        {
            dgvElements = new List<Entity>();
            this.dgv = dgv;
            objectRepository = repositoryFactory.GetObjectRepository();//new ObjectRepository();
            ownerRepository = repositoryFactory.GetOwnerRepository();//new PersonRepository("Owner");
        }
        public Dictionary<int, Entity> ShowTable(bool sort = false)
        {
            try
            {
                var owners = ownerRepository.GetTable();
                dgvElements = objectRepository.GetTable();
                dgv.Rows.Clear();
                //id,address,adddate,cost,owner,apart,area,rooms
                foreach (Entity obj in dgvElements)
                {
                    //MessageBox.Show(obj.cost.ToString("N2") + " " + obj.area.ToString("N2"));
                    string ownerText = null;
                    foreach (Person owner in owners)
                        if (owner.id == obj.owner)
                        {
                            ownerText = String.Format("{0} {1}", owner.surname, owner.name);
                            break;
                        }
                    dgv.Rows.Add(obj.id, obj.address, obj.addDate.ToString("dd/MM/yyyy"), obj.cost.ToString("N2"), ownerText, obj.apartmentOrHouse, obj.area.ToString("N2"), obj.numberOfRooms);
                }
            }
            catch (PostgresException pEx) { MessageBox.Show("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            catch (Exception ex) { MessageBox.Show("Неизвестная ошибка.\r\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            if (sort)
                dgv.Sort(dgv.Columns[0], ListSortDirection.Ascending);

            Dictionary<int, Entity> dict = new Dictionary<int, Entity>();
            foreach (var el in dgvElements)
                dict.Add(el.id, el);
            return dict;
        }
        public bool AddToTable(Entity obj)
        {
            List<string> errorList;
            bool checkFlag = ObjectValidator.checkAddition(obj, out errorList);
            try
            {
                if (checkFlag)
                    objectRepository.AddToTable(obj);
            }
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool UpdateTable(Entity obj)
        {
            List<string> errorList;
            bool checkFlag = ObjectValidator.checkAddition(obj, out errorList);
            try
            {
                if (checkFlag)
                    objectRepository.UpdateTable(obj);
            }
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }
        public bool DeleteFromTable(int id)
        {
            List<string> errorList;
            bool checkFlag = ObjectValidator.checkDelete(id, out errorList);
            try
            {
                if (checkFlag)
                    objectRepository.DeleteFromTable(id);
            }
            catch (Npgsql.PostgresException pEx) { errorList.Add("Ошибка базы данных.\r\nКод ошибки: " + pEx.SqlState); checkFlag = false; }
            catch (Exception) { errorList.Add("Ошибка базы данных."); checkFlag = false; }

            ShowErrors(errorList);

            return checkFlag;
        }

        private void ShowErrors(List<string> errorList)
        {
            if (errorList.Count == 0)
                return;

            string errors = "";
            foreach (string s in errorList)
                errors += s + System.Environment.NewLine;
            MessageBox.Show(errors, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
