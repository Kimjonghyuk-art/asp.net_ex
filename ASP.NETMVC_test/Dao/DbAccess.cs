﻿using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace ASP.NETMVC_test.Dao
{
    public class DbAccess
    {
        #region クラス変数

        public MySqlConnection sqlCon { get; private set; }
        public MySqlTransaction sqlTran { get; private set; }

        #endregion

        #region 独自メソッド

        #region DBオープン
        /// <summary>
        /// データベースに接続
        /// </summary>
        public DbAccess()
        {
            try
            {
        string sConnection = "Server=localhost; Port=3306; database=test; Uid=root; Pwd=1234"
  ;
              //SqlConnection の新しいインスタンスを生成する (接続文字列を指定)
              this.sqlCon = new MySqlConnection(sConnection);
              // データベース接続を開く
              this.sqlCon.Open();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region トランザクション開始

        /// <summary>
        /// トランザクション開始
        /// </summary>
        /// <param name="cmd">SQLコマンド</param>
        public void beginTransaction(MySqlCommand cmd)
        {
            try
            {
                if (this.sqlCon.State != ConnectionState.Open)
                {
                    this.sqlCon.Open();
                }

                //トランザクションの開始
                this.sqlTran = this.sqlCon.BeginTransaction();

            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// トランザクション再設定
        /// (トランザクション開始後に、①SELECT②INSERTorUPDATEを実行する場合に使用する)
        /// </summary>
        /// <param name="cmd">SQLコマンド</param>
        public void setTransaction(MySqlCommand cmd)
        {
            try
            {
                cmd.Transaction = this.sqlTran;
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region コミット

        /// <summary>
        /// コミット
        /// </summary>
        public void commit()
        {
            if (this.sqlTran.Connection != null)
            {
                this.sqlTran.Commit();
                this.sqlTran.Dispose();
            }
        }

        #endregion

        #region ロールバック

        /// <summary>
        /// ロールバック
        /// </summary>
        public void rollback()
        {
            if (this.sqlTran.Connection != null)
            {
                this.sqlTran.Rollback();
                this.sqlTran.Dispose();
            }
        }

        #endregion

        #region DBクローズ

        /// <summary>
        /// DBを閉じる
        /// </summary>
        public void close()
        {
            // データベース接続を閉じる 
            this.sqlCon.Close();
            this.sqlCon.Dispose();
        }

        #endregion

        #region データ取得

        /// <summary>
        /// SELECT文を実行してDataTableを返却する
        /// </summary>
        /// <param name="cmd">SQLを実行するためのオブジェクト</param>
        /// <returns>データテーブル</returns>
        public DataTable executeQuery(MySqlCommand cmd)
        {
           //SQLを実行する。
            MySqlDataReader read = cmd.ExecuteReader();
            try
            {
                //取得した情報をdtにセットする。
                DataTable dt = new DataTable();
                dt.Load(read);

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                read.Close();
                read.Dispose();
            }
        }

        #endregion

        #region クエリ実行
        /// <summary>
        /// 登録・更新・削除を実行する
        /// </summary>
        /// <param name="cmd">SQLを実行するためのオブジェクト</param>
        /// <returns>真偽値。成功でtrue、失敗でfalseを返す</returns>
        public int executeNonQuery(MySqlCommand cmd)
        {
            try
            {
                if (this.sqlCon.State != ConnectionState.Open)
                {
                    this.sqlCon.Open();
                }
                if (this.sqlTran != null)
                {
                    cmd.Transaction = this.sqlTran;
                }

                // SQLを実行する。
                int result = cmd.ExecuteNonQuery();

                // 実行件数を戻り値に設定する
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 登録処理を実行
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>登録時のPRIMARY_KEY</returns>
        public int executeScalarQuery(MySqlCommand cmd)
        {
            try
            {
                if (this.sqlCon.State != ConnectionState.Open)
                {
                    this.sqlCon.Open();
                }
                if (this.sqlTran != null)
                {
                    cmd.Transaction = this.sqlTran;
                }

                // 登録時のPRIMARY_KEYを戻り値に設定する
                return (int) (decimal) cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 登録処理を実行し、OUTPUT句で指定した値を返却する
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>OUTPUT句で指定した値</returns>
        public int executeScalarQueryAndGetOutputValue(MySqlCommand cmd)
        {
            try
            {
                if (this.sqlCon.State != ConnectionState.Open)
                {
                    this.sqlCon.Open();
                }
                if (this.sqlTran != null)
                {
                    cmd.Transaction = this.sqlTran;
                }

                return (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #endregion

    }
}
