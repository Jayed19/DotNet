using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.Collections;

using System.Data;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System.Windows.Forms;

using NID2.Client.SDK;
using NID2.Client.SDK.Models;
using System.Diagnostics;
using BvrsRestLibTestModule.Utils;
using BvrsRestLibTestModule.Models;

namespace BvrsRestLibTestModule.Services
{
    internal class RESTManager
    {

        private readonly VoterUploadClient _client = new VoterUploadClient();        
        string m_rest_user = "ext_service_user";
        string m_rest_pass = "S3rAic3Us@r987";
        string m_session = "eyJ0eXAiOiJhY2Nlc3NfdG9rZW4iLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ3b3Jrc3RhdGlvbl9yZWdpc3RyYXIiLCJyb2xlcyI6WyJXT1JLU1RBVElPTl9SRUdJU1RSQVRJT04iXSwiaWF0IjoxNjE3MDEzNTE2LCJleHAiOjE2NDg1NDk1MTZ9.gPQ-R91DE7wUKcMTBq-ubEIr8wUIC3zdBdiZExk8KzM";

        public Counter RegisterCounter(Counter counter)
        {
            var sw = new Stopwatch();
            var counterResponse = new Counter();
            try
            {

                NID2.Client.SDK.Services.WorkstationRegistrationRequest request = new NID2.Client.SDK.Services.WorkstationRegistrationRequest();
                NID2.Client.SDK.Models.WorkstationInfo workstation = new NID2.Client.SDK.Models.WorkstationInfo();
                NID2.Client.SDK.Models.ProductKeyInfo productKey = new NID2.Client.SDK.Models.ProductKeyInfo();
               
                var c = counter.CounterType.Equals(CounterType.FIXED.GetStringValue())
                    ? CounterType.FIXED.GetStringValue()
                    : CounterType.MOBILE.GetStringValue();

                workstation = new NID2.Client.SDK.Models.WorkstationInfo()
                {
                    MachineUuid = counter.ProductUuId,
                    Country = counter.CountryId,
                    Division = counter.DivisionId,
                    District = counter.ZilaId,
                    Upozila = counter.UpazilaId,
                    CounterId = counter.CounterId,
                    MachineCpu = counter.MahcineCpuId,
                    MachineHdd = counter.MachineHddId,
                    MachineMac = counter.MachineMacId,
                    CounterType = c
                };
                productKey.ProductKey = counter.ProductKey;
                request.Workstation = workstation;
                request.ProductName = counter.ProductName;


                TLog.Info("Start calling 'registerWorkstation' service... Counter ID:" + counter.CounterId + ", Product key: " + counter.ProductKey + ", Upazila ID: " + counter.UpazilaId);
                sw.Start();

                var response = _client.WorkstationRegistration(productKey, workstation, counter.ProductName, m_session);

                if (response.IsSuccess)
                {
                    if (sw.IsRunning)
                    {
                        sw.Stop();
                        TimeSpan ts = sw.Elapsed;
                        string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                        TLog.Info("To register workstation [service : WorkstationRegistration]: " + elapsedTime);
                    }
                    counterResponse.ProductKey = counter.ProductKey;
                    counterResponse.ProductUuId = request.Workstation.MachineUuid;
                    counterResponse.MachineHddId = request.Workstation.MachineHdd;
                    counterResponse.MahcineCpuId = request.Workstation.MachineCpu;
                    counterResponse.MachineMacId = request.Workstation.MachineMac;
                    counterResponse.CounterId = request.Workstation.CounterId;
                    counterResponse.UpazilaId = counter.UpazilaId;
                    counterResponse.Hash256 = response.Data.HashData;
                    counterResponse.ExpiryDate = response.Data.LicenseExpiredOn;
                    counterResponse.PublicKey = response.Data.PublicKeyString;
                    counterResponse.PublicKeyEncodedByte = response.Data.PublicKey;
                    counterResponse.Signature = Convert.ToBase64String(response.Data.Signature);
                }
                else
                {
                    if (response.Message != null)
                        throw new Exception(response.Message);
                    else
                    {
                        if (response.ErrorList != null)
                        {
                            if (response.ErrorList.Length > 0)
                            {
                                for (int i = 0; i < response.ErrorList.Length; i++)
                                {
                                    if (response.ErrorList[i] != null) throw new Exception(response.ErrorList[i].Message);
                                }
                            }
                        }
                        else
                        {
                            //
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (sw.IsRunning)
                {
                    sw.Stop();
                    TimeSpan ts = sw.Elapsed;
                    string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                    TLog.Info("To response [service : registerWorkstation]: " + elapsedTime);
                }
                TLog.Error(ex.Message, ex);
                if (Utils.Utils.CaseInsensitiveContains(ex.Message, "Workstation's Machine UUIDalready exists."))
                {
                    throw new Exception("This Workstation is already registered!");
                }
                if (Utils.Utils.CaseInsensitiveContains(ex.Message, "Workstation's Counter Id already exists."))
                {
                    throw new Exception("Workstation's Counter ID already exists.");
                }
                if (Utils.Utils.CaseInsensitiveContains(ex.Message, "Unable to connect"))
                {
                    throw new Exception("Unable to connect the remote server. Please check the connectivity or service IP");
                }
                if (ex.Message.Equals("Station is inactive"))
                {
                    throw new Exception("Workstation is inactive");
                }
                if (Utils.Utils.CaseInsensitiveContains(ex.Message, "No Product key found"))
                {
                    throw new Exception("Product key is invalid");
                }
                if (Utils.Utils.CaseInsensitiveContains(ex.Message, "Product key already used"))
                {
                    throw new Exception("Product key is already used");
                }
                if (Utils.Utils.CaseInsensitiveContains(ex.Message, "unique constraint (VOTER.UK_WS_COUNTER_ID) violated"))
                {
                    throw new Exception("Workstation's Counter ID already exists.");
                }
                if (Utils.Utils.CaseInsensitiveContains(ex.Message, "Illegal character entity: expansion character"))
                {
                    throw new Exception("Please locate valid workstation particular file");
                }
                throw new Exception(ex.Message);
            }
            return counterResponse;
        }
    }
}
