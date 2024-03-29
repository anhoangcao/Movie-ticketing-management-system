﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_Phim
    {
        string stringConnect = @"Server=DESKTOP-0MK0TTK;Database=tesst;integrated security=true";
        public DataTable ListPhim()
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                SqlCommand comd = new SqlCommand("SELECT a.MaPhim, a.TenPhim, a.MoTa, b.TenLoaiPhim, a.ThoiLuong, a.SanXuat, a.DaoDien, a.HinhAnh FROM dbo.Phim as a, dbo.LoaiPhim as b where a.MaLoaiPhim = b.MaLoaiPhim", conn);
                comd.CommandType = CommandType.Text;
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }

        // Insert Phim
        public bool insertPhim(DTO_Phim p)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string sql = "INSERT INTO dbo.Phim (MaPhim, TenPhim, MoTa, MaLoaiPhim, ThoiLuong, SanXuat, DaoDien, HinhAnh) VALUES (@MaPhim, @TenPhim, @MoTa, @MaLoaiPhim, @ThoiLuong, @SanXuat, @DaoDien, @HinhAnh)";
                SqlCommand comd = new SqlCommand(sql, conn);
                comd.Parameters.AddWithValue("@MaPhim", p.MaPhim);
                comd.Parameters.AddWithValue("@TenPhim", p.TenPhim);
                comd.Parameters.AddWithValue("@MoTa", p.MoTa);
                comd.Parameters.AddWithValue("@MaLoaiPhim", p.MaLP);
                comd.Parameters.AddWithValue("@ThoiLuong", p.ThoiLuong);
                comd.Parameters.AddWithValue("@SanXuat", p.SanXuat);
                comd.Parameters.AddWithValue("@DaoDien", p.DaoDien);
                comd.Parameters.AddWithValue("@HinhAnh", p.PosTer);
                if (comd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        // Update Phim
        public bool updatePhim(DTO_Phim p)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string sql = "UPDATE dbo.Phim SET MaPhim = @MaPhim, TenPhim = @TenPhim, MoTa = @MoTa, MaLoaiPhim = @MaLoaiPhim, ThoiLuong = @ThoiLuong, SanXuat = @SanXuat, DaoDien = @DaoDien, HinhAnh = @HinhAnh WHERE MaPhim = @MaPhim";
                SqlCommand comd = new SqlCommand(sql, conn);
                comd.Parameters.AddWithValue("@MaPhim", p.MaPhim);
                comd.Parameters.AddWithValue("@TenPhim", p.TenPhim);
                comd.Parameters.AddWithValue("@MoTa", p.MoTa);
                comd.Parameters.AddWithValue("@MaLoaiPhim", p.MaLP);
                comd.Parameters.AddWithValue("@ThoiLuong", p.ThoiLuong);
                comd.Parameters.AddWithValue("@SanXuat", p.SanXuat);
                comd.Parameters.AddWithValue("@DaoDien", p.DaoDien);
                comd.Parameters.AddWithValue("@HinhAnh", p.PosTer);
                if (comd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }

            return false;
        }

        // Delete Film
        public bool deletePhim(String MaPhim)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "Delete from Phim where MaPhim = '" + MaPhim + "'";
                SqlCommand command = new SqlCommand(query, conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("MaPC", MaPhim);
                if (command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return false;
        }

        public DataTable searchP(string p)
        {
            SqlConnection conn = new SqlConnection(stringConnect);
            try
            {
                conn.Open();
                string query = "SELECT a.MaPhim, a.TenPhim, a.MoTa, b.TenLoaiPhim, a.ThoiLuong, a.SanXuat, a.DaoDien, a.HinhAnh " +
                               "FROM dbo.Phim as a " +
                               "JOIN dbo.LoaiPhim as b ON a.MaLoaiPhim = b.MaLoaiPhim " +
                               "WHERE a.TenPhim LIKE '%' + @p + '%' or b.TenLoaiPhim LIKE '%' + @p + '%' or a.SanXuat LIKE '%' + @p + '%'";
                SqlCommand comd = new SqlCommand(query, conn);
                comd.CommandType = CommandType.Text;
                comd.Parameters.AddWithValue("@p", p);
                DataTable data = new DataTable();
                data.Load(comd.ExecuteReader());
                return data;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
