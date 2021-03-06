// ReSharper disable All
using MixERP.Net.DbFactory;
using MixERP.Net.Framework;
using MixERP.Net.Framework.Extensions;
using PetaPoco;
using MixERP.Net.Entities.Transactions;
using Npgsql;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MixERP.Net.Schemas.Transactions.Data
{
    /// <summary>
    /// Prepares, validates, and executes the function "transactions.post_purchase(_book_name character varying, _office_id integer, _user_id integer, _login_id bigint, _value_date date, _cost_center_id integer, _reference_number character varying, _statement_reference text, _is_credit boolean, _party_code character varying, _price_type_id integer, _shipper_id integer, _store_id integer, _tran_ids bigint[], _details transactions.stock_detail_type[], _attachments core.attachment_type[])" on the database.
    /// </summary>
    public class PostPurchaseProcedure : DbAccess, IPostPurchaseRepository
    {
        /// <summary>
        /// The schema of this PostgreSQL function.
        /// </summary>
        public override string _ObjectNamespace => "transactions";
        /// <summary>
        /// The schema unqualified name of this PostgreSQL function.
        /// </summary>
        public override string _ObjectName => "post_purchase";
        /// <summary>
        /// Login id of application user accessing this PostgreSQL function.
        /// </summary>
        public long _LoginId { get; set; }
        /// <summary>
        /// User id of application user accessing this table.
        /// </summary>
        public int _UserId { get; set; }
        /// <summary>
        /// The name of the database on which queries are being executed to.
        /// </summary>
        public string _Catalog { get; set; }

        /// <summary>
        /// Maps to "_book_name" argument of the function "transactions.post_purchase".
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// Maps to "_office_id" argument of the function "transactions.post_purchase".
        /// </summary>
        public int OfficeId { get; set; }
        /// <summary>
        /// Maps to "_user_id" argument of the function "transactions.post_purchase".
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Maps to "_login_id" argument of the function "transactions.post_purchase".
        /// </summary>
        public long LoginId { get; set; }
        /// <summary>
        /// Maps to "_value_date" argument of the function "transactions.post_purchase".
        /// </summary>
        public DateTime ValueDate { get; set; }
        /// <summary>
        /// Maps to "_cost_center_id" argument of the function "transactions.post_purchase".
        /// </summary>
        public int CostCenterId { get; set; }
        /// <summary>
        /// Maps to "_reference_number" argument of the function "transactions.post_purchase".
        /// </summary>
        public string ReferenceNumber { get; set; }
        /// <summary>
        /// Maps to "_statement_reference" argument of the function "transactions.post_purchase".
        /// </summary>
        public string StatementReference { get; set; }
        /// <summary>
        /// Maps to "_is_credit" argument of the function "transactions.post_purchase".
        /// </summary>
        public bool IsCredit { get; set; }
        /// <summary>
        /// Maps to "_party_code" argument of the function "transactions.post_purchase".
        /// </summary>
        public string PartyCode { get; set; }
        /// <summary>
        /// Maps to "_price_type_id" argument of the function "transactions.post_purchase".
        /// </summary>
        public int PriceTypeId { get; set; }
        /// <summary>
        /// Maps to "_shipper_id" argument of the function "transactions.post_purchase".
        /// </summary>
        public int ShipperId { get; set; }
        /// <summary>
        /// Maps to "_store_id" argument of the function "transactions.post_purchase".
        /// </summary>
        public int StoreId { get; set; }
        /// <summary>
        /// Maps to "_tran_ids" argument of the function "transactions.post_purchase".
        /// </summary>
        public long[] TranIds { get; set; }
        /// <summary>
        /// Maps to "_details" argument of the function "transactions.post_purchase".
        /// </summary>
        public MixERP.Net.Entities.Transactions.StockDetailType[] Details { get; set; }
        /// <summary>
        /// Maps to "_attachments" argument of the function "transactions.post_purchase".
        /// </summary>
        public MixERP.Net.Entities.Core.AttachmentType[] Attachments { get; set; }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.post_purchase(_book_name character varying, _office_id integer, _user_id integer, _login_id bigint, _value_date date, _cost_center_id integer, _reference_number character varying, _statement_reference text, _is_credit boolean, _party_code character varying, _price_type_id integer, _shipper_id integer, _store_id integer, _tran_ids bigint[], _details transactions.stock_detail_type[], _attachments core.attachment_type[])" on the database.
        /// </summary>
        public PostPurchaseProcedure()
        {
        }

        /// <summary>
        /// Prepares, validates, and executes the function "transactions.post_purchase(_book_name character varying, _office_id integer, _user_id integer, _login_id bigint, _value_date date, _cost_center_id integer, _reference_number character varying, _statement_reference text, _is_credit boolean, _party_code character varying, _price_type_id integer, _shipper_id integer, _store_id integer, _tran_ids bigint[], _details transactions.stock_detail_type[], _attachments core.attachment_type[])" on the database.
        /// </summary>
        /// <param name="bookName">Enter argument value for "_book_name" parameter of the function "transactions.post_purchase".</param>
        /// <param name="officeId">Enter argument value for "_office_id" parameter of the function "transactions.post_purchase".</param>
        /// <param name="userId">Enter argument value for "_user_id" parameter of the function "transactions.post_purchase".</param>
        /// <param name="loginId">Enter argument value for "_login_id" parameter of the function "transactions.post_purchase".</param>
        /// <param name="valueDate">Enter argument value for "_value_date" parameter of the function "transactions.post_purchase".</param>
        /// <param name="costCenterId">Enter argument value for "_cost_center_id" parameter of the function "transactions.post_purchase".</param>
        /// <param name="referenceNumber">Enter argument value for "_reference_number" parameter of the function "transactions.post_purchase".</param>
        /// <param name="statementReference">Enter argument value for "_statement_reference" parameter of the function "transactions.post_purchase".</param>
        /// <param name="isCredit">Enter argument value for "_is_credit" parameter of the function "transactions.post_purchase".</param>
        /// <param name="partyCode">Enter argument value for "_party_code" parameter of the function "transactions.post_purchase".</param>
        /// <param name="priceTypeId">Enter argument value for "_price_type_id" parameter of the function "transactions.post_purchase".</param>
        /// <param name="shipperId">Enter argument value for "_shipper_id" parameter of the function "transactions.post_purchase".</param>
        /// <param name="storeId">Enter argument value for "_store_id" parameter of the function "transactions.post_purchase".</param>
        /// <param name="tranIds">Enter argument value for "_tran_ids" parameter of the function "transactions.post_purchase".</param>
        /// <param name="details">Enter argument value for "_details" parameter of the function "transactions.post_purchase".</param>
        /// <param name="attachments">Enter argument value for "_attachments" parameter of the function "transactions.post_purchase".</param>
        public PostPurchaseProcedure(string bookName, int officeId, int userId, long loginId, DateTime valueDate, int costCenterId, string referenceNumber, string statementReference, bool isCredit, string partyCode, int priceTypeId, int shipperId, int storeId, long[] tranIds, MixERP.Net.Entities.Transactions.StockDetailType[] details, MixERP.Net.Entities.Core.AttachmentType[] attachments)
        {
            this.BookName = bookName;
            this.OfficeId = officeId;
            this.UserId = userId;
            this.LoginId = loginId;
            this.ValueDate = valueDate;
            this.CostCenterId = costCenterId;
            this.ReferenceNumber = referenceNumber;
            this.StatementReference = statementReference;
            this.IsCredit = isCredit;
            this.PartyCode = partyCode;
            this.PriceTypeId = priceTypeId;
            this.ShipperId = shipperId;
            this.StoreId = storeId;
            this.TranIds = tranIds;
            this.Details = details;
            this.Attachments = attachments;
        }
        /// <summary>
        /// Prepares and executes the function "transactions.post_purchase".
        /// </summary>
        /// <exception cref="UnauthorizedException">Thown when the application user does not have sufficient privilege to perform this action.</exception>
        public long Execute()
        {
            if (!this.SkipValidation)
            {
                if (!this.Validated)
                {
                    this.Validate(AccessTypeEnum.Execute, this._LoginId, this._Catalog, false);
                }
                if (!this.HasAccess)
                {
                    Log.Information("Access to the function \"PostPurchaseProcedure\" was denied to the user with Login ID {LoginId}.", this._LoginId);
                    throw new UnauthorizedException("Access is denied.");
                }
            }
            string query = "SELECT * FROM transactions.post_purchase(@BookName, @OfficeId, @UserId, @LoginId, @ValueDate, @CostCenterId, @ReferenceNumber, @StatementReference, @IsCredit, @PartyCode, @PriceTypeId, @ShipperId, @StoreId, @TranIds, @Details, @Attachments);";

            query = query.ReplaceWholeWord("@BookName", "@0::character varying");
            query = query.ReplaceWholeWord("@OfficeId", "@1::integer");
            query = query.ReplaceWholeWord("@UserId", "@2::integer");
            query = query.ReplaceWholeWord("@LoginId", "@3::bigint");
            query = query.ReplaceWholeWord("@ValueDate", "@4::date");
            query = query.ReplaceWholeWord("@CostCenterId", "@5::integer");
            query = query.ReplaceWholeWord("@ReferenceNumber", "@6::character varying");
            query = query.ReplaceWholeWord("@StatementReference", "@7::text");
            query = query.ReplaceWholeWord("@IsCredit", "@8::boolean");
            query = query.ReplaceWholeWord("@PartyCode", "@9::character varying");
            query = query.ReplaceWholeWord("@PriceTypeId", "@10::integer");
            query = query.ReplaceWholeWord("@ShipperId", "@11::integer");
            query = query.ReplaceWholeWord("@StoreId", "@12::integer");

            int tranIdsOffset = 13;
            query = query.ReplaceWholeWord("@TranIds", "ARRAY[" + this.SqlForTranIds(this.TranIds, tranIdsOffset, 1) + "]");

            int detailsOffset = tranIdsOffset + (this.TranIds == null ? 0 : this.TranIds.Count() * 1)/*The object TranIds has 1 member(s).*/;
            query = query.ReplaceWholeWord("@Details", "ARRAY[" + this.SqlForDetails(this.Details, detailsOffset, 9) + "]");

            int attachmentsOffset = detailsOffset + (this.Details == null ? 0 : this.Details.Count() * 9)/*The object Details has 9 member(s).*/;
            query = query.ReplaceWholeWord("@Attachments", "ARRAY[" + this.SqlForAttachments(this.Attachments, attachmentsOffset, 4) + "]");


            List<object> parameters = new List<object>();
            parameters.Add(this.BookName);
            parameters.Add(this.OfficeId);
            parameters.Add(this.UserId);
            parameters.Add(this.LoginId);
            parameters.Add(this.ValueDate);
            parameters.Add(this.CostCenterId);
            parameters.Add(this.ReferenceNumber);
            parameters.Add(this.StatementReference);
            parameters.Add(this.IsCredit);
            parameters.Add(this.PartyCode);
            parameters.Add(this.PriceTypeId);
            parameters.Add(this.ShipperId);
            parameters.Add(this.StoreId);
            parameters.AddRange(this.ParamsForTranIds(this.TranIds));
            parameters.AddRange(this.ParamsForDetails(this.Details));
            parameters.AddRange(this.ParamsForAttachments(this.Attachments));

            return Factory.Scalar<long>(this._Catalog, query, parameters.ToArray());
        }

        private string SqlForTranIds(long[] tranIds, int offset, int memberCount)
        {
            if (tranIds == null)
            {
                return "NULL::bigint";
            }
            List<string> parameters = new List<string>();
            for (int i = 0; i < tranIds.Count(); i++)
            {
                List<string> args = new List<string>();
                args.Add("@" + offset);
                offset++;
                string parameter = "{0}::bigint";
                parameter = string.Format(System.Globalization.CultureInfo.InvariantCulture, parameter,
                    string.Join(",", args));
                parameters.Add(parameter);
            }
            return string.Join(",", parameters);
        }

        private List<object> ParamsForTranIds(long[] tranIds)
        {
            List<object> collection = new List<object>();

            if (tranIds != null && tranIds.Count() > 0)
            {
                foreach (long tranId in tranIds)
                {
                    collection.Add(tranId);
                }
            }
            return collection;
        }
        private string SqlForDetails(MixERP.Net.Entities.Transactions.StockDetailType[] details, int offset, int memberCount)
        {
            if (details == null)
            {
                return "NULL::transactions.stock_detail_type";
            }
            List<string> parameters = new List<string>();
            for (int i = 0; i < details.Count(); i++)
            {
                List<string> args = new List<string>();
                for (int j = 0; j < memberCount; j++)
                {
                    args.Add("@" + offset);
                    offset++;
                }

                string parameter = "ROW({0})::transactions.stock_detail_type";
                parameter = string.Format(System.Globalization.CultureInfo.InvariantCulture, parameter,
                    string.Join(",", args));
                parameters.Add(parameter);
            }
            return string.Join(",", parameters);
        }

        private List<object> ParamsForDetails(MixERP.Net.Entities.Transactions.StockDetailType[] details)
        {
            List<object> collection = new List<object>();

            if (details != null && details.Count() > 0)
            {
                foreach (MixERP.Net.Entities.Transactions.StockDetailType detail in details)
                {
                    collection.Add(detail.StoreId);
                    collection.Add(detail.ItemCode);
                    collection.Add(detail.Quantity);
                    collection.Add(detail.UnitName);
                    collection.Add(detail.Price);
                    collection.Add(detail.Discount);
                    collection.Add(detail.ShippingCharge);
                    collection.Add(detail.TaxForm);
                    collection.Add(detail.Tax);
                    collection.Add(detail);
                }
            }
            return collection;
        }
        private string SqlForAttachments(MixERP.Net.Entities.Core.AttachmentType[] attachments, int offset, int memberCount)
        {
            if (attachments == null)
            {
                return "NULL::core.attachment_type";
            }
            List<string> parameters = new List<string>();
            for (int i = 0; i < attachments.Count(); i++)
            {
                List<string> args = new List<string>();
                for (int j = 0; j < memberCount; j++)
                {
                    args.Add("@" + offset);
                    offset++;
                }

                string parameter = "ROW({0})::core.attachment_type";
                parameter = string.Format(System.Globalization.CultureInfo.InvariantCulture, parameter,
                    string.Join(",", args));
                parameters.Add(parameter);
            }
            return string.Join(",", parameters);
        }

        private List<object> ParamsForAttachments(MixERP.Net.Entities.Core.AttachmentType[] attachments)
        {
            List<object> collection = new List<object>();

            if (attachments != null && attachments.Count() > 0)
            {
                foreach (MixERP.Net.Entities.Core.AttachmentType attachment in attachments)
                {
                    collection.Add(attachment.Comment);
                    collection.Add(attachment.FilePath);
                    collection.Add(attachment.OriginalFileName);
                    collection.Add(attachment.FileExtension);
                    collection.Add(attachment);
                }
            }
            return collection;
        }
    }
}