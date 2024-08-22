//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Configuration;
//using System.Reflection;
//using System.Data.Common;
//using System.Data;
//using System.Data.SqlClient;

//namespace ShanaiKanri.Dao
//{
//    public class DbAccess
//    {
//        #region �N���X�ϐ�

//        public SqlConnection sqlCon { get; private set; }
//        public SqlTransaction sqlTran { get; private set; }

//        #endregion

//        #region �Ǝ����\�b�h

//        #region DB�I�[�v��
//        /// <summary>
//        /// �f�[�^�x�[�X�ɐڑ�
//        /// </summary>
//        public DbAccess()
//        {
//            try
//            {
//                string sConnection = Properties.Resources.dbConnection;

//                //SqlConnection �̐V�����C���X�^���X�𐶐����� (�ڑ���������w��)
//                this.sqlCon = new SqlConnection(sConnection);
//                // �f�[�^�x�[�X�ڑ����J��
//                this.sqlCon.Open();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        #endregion

//        #region �g�����U�N�V�����J�n

//        /// <summary>
//        /// �g�����U�N�V�����J�n
//        /// </summary>
//        /// <param name="cmd">SQL�R�}���h</param>
//        public void beginTransaction(SqlCommand cmd)
//        {
//            try
//            {
//                if (this.sqlCon.State != ConnectionState.Open)
//                {
//                    this.sqlCon.Open();
//                }

//                //�g�����U�N�V�����̊J�n
//                this.sqlTran = this.sqlCon.BeginTransaction();

//            }
//            catch (Exception)
//            {
//                throw;
//            }

//        }


//        /// <summary>
//        /// �g�����U�N�V�����Đݒ�
//        /// (�g�����U�N�V�����J�n��ɁA�@SELECT�AINSERTorUPDATE�����s����ꍇ�Ɏg�p����)
//        /// </summary>
//        /// <param name="cmd">SQL�R�}���h</param>
//        public void setTransaction(SqlCommand cmd)
//        {
//            try
//            {
//                cmd.Transaction = this.sqlTran;
//            }
//            catch
//            {
//                throw;
//            }
//        }

//        #endregion

//        #region �R�~�b�g

//        /// <summary>
//        /// �R�~�b�g
//        /// </summary>
//        public void commit()
//        {
//            if (this.sqlTran.Connection != null)
//            {
//                this.sqlTran.Commit();
//                this.sqlTran.Dispose();
//            }
//        }

//        #endregion

//        #region ���[���o�b�N

//        /// <summary>
//        /// ���[���o�b�N
//        /// </summary>
//        public void rollback()
//        {
//            if (this.sqlTran.Connection != null)
//            {
//                this.sqlTran.Rollback();
//                this.sqlTran.Dispose();
//            }
//        }

//        #endregion

//        #region DB�N���[�Y

//        /// <summary>
//        /// DB�����
//        /// </summary>
//        public void close()
//        {
//            // �f�[�^�x�[�X�ڑ������ 
//            this.sqlCon.Close();
//            this.sqlCon.Dispose();
//        }

//        #endregion

//        #region �f�[�^�擾

//        /// <summary>
//        /// SELECT�������s����DataTable��ԋp����
//        /// </summary>
//        /// <param name="cmd">SQL�����s���邽�߂̃I�u�W�F�N�g</param>
//        /// <returns>�f�[�^�e�[�u��</returns>
//        public DataTable executeQuery(SqlCommand cmd)
//        {
//            //SQL�����s����B
//            SqlDataReader read = cmd.ExecuteReader();
//            try
//            {
//                //�擾��������dt�ɃZ�b�g����B
//                DataTable dt = new DataTable();
//                dt.Load(read);

//                return dt;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            finally
//            {
//                read.Close();
//                read.Dispose();
//            }
//        }

//        #endregion

//        #region �N�G�����s
//        /// <summary>
//        /// �o�^�E�X�V�E�폜�����s����
//        /// </summary>
//        /// <param name="cmd">SQL�����s���邽�߂̃I�u�W�F�N�g</param>
//        /// <returns>�^�U�l�B������true�A���s��false��Ԃ�</returns>
//        public int executeNonQuery(SqlCommand cmd)
//        {
//            try
//            {
//                if (this.sqlCon.State != ConnectionState.Open)
//                {
//                    this.sqlCon.Open();
//                }
//                if (this.sqlTran != null)
//                {
//                    cmd.Transaction = this.sqlTran;
//                }

//                // SQL�����s����B
//                int result = cmd.ExecuteNonQuery();

//                // ���s������߂�l�ɐݒ肷��
//                return result;

//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        /// <summary>
//        /// �o�^���������s
//        /// </summary>
//        /// <param name="cmd"></param>
//        /// <returns>�o�^����PRIMARY_KEY</returns>
//        public int executeScalarQuery(SqlCommand cmd)
//        {
//            try
//            {
//                if (this.sqlCon.State != ConnectionState.Open)
//                {
//                    this.sqlCon.Open();
//                }
//                if (this.sqlTran != null)
//                {
//                    cmd.Transaction = this.sqlTran;
//                }

//                // �o�^����PRIMARY_KEY��߂�l�ɐݒ肷��
//                return (int)(decimal)cmd.ExecuteScalar();

//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }

//        /// <summary>
//        /// �o�^���������s���AOUTPUT��Ŏw�肵���l��ԋp����
//        /// </summary>
//        /// <param name="cmd"></param>
//        /// <returns>OUTPUT��Ŏw�肵���l</returns>
//        public int executeScalarQueryAndGetOutputValue(SqlCommand cmd)
//        {
//            try
//            {
//                if (this.sqlCon.State != ConnectionState.Open)
//                {
//                    this.sqlCon.Open();
//                }
//                if (this.sqlTran != null)
//                {
//                    cmd.Transaction = this.sqlTran;
//                }

//                return (int)cmd.ExecuteScalar();

//            }
//            catch (Exception ex)
//            {
//                throw;
//            }
//        }
//        #endregion

//        #endregion

//    }
//}
