using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ChatRooms",
                columns: new[] { "Id", "CreatedAt", "Theme" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 17, 15, 58, 43, 468, DateTimeKind.Local).AddTicks(2178), "Light" },
                    { 2, new DateTime(2024, 9, 17, 15, 48, 43, 468, DateTimeKind.Local).AddTicks(2186), "Dark" }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Toàn bộ khách hàng thông thường có mua hàng nhưng ít", "Khách hàng thông thường" },
                    { 2, "Toàn bộ khách hàng thân thiết, thường xuyên mua hàng", "Khách hàng thân thiết" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Body", "CreatedAt", "IsRead", "Title" },
                values: new object[,]
                {
                    { 1, "Hãy kiểm tra tài khoản của bạn để biết thêm thông tin.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2765), false, "Thông báo quan trọng" },
                    { 2, "Hệ thống sẽ bảo trì từ 2 AM đến 4 AM ngày mai.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2768), false, "Cập nhật hệ thống" },
                    { 3, "Nhận ngay 20% giảm giá cho đơn hàng đầu tiên của bạn!", new DateTime(2024, 9, 16, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2770), true, "Tin khuyến mãi" },
                    { 4, "Bạn có một hóa đơn chưa thanh toán. Vui lòng thanh toán ngay.", new DateTime(2024, 9, 15, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2772), false, "Nhắc nhở thanh toán" }
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Mỹ phẩm là các sản phẩm chăm sóc cá nhân được thiết kế để làm đẹp, bảo vệ hoặc cải thiện vẻ ngoài của da, tóc, móng và cơ thể. Chúng bao gồm nhiều loại sản phẩm như kem dưỡng da, son môi, phấn nền, mascara, dầu gội, và nước hoa. Mỹ phẩm có thể chứa các thành phần tự nhiên hoặc tổng hợp, giúp làm sạch, dưỡng ẩm, chống lão hóa, và bảo vệ da khỏi các tác động xấu từ môi trường.", "Mỹ phẩm" },
                    { 2, "Sản phẩm gia dụng là các vật dụng được sử dụng hàng ngày trong gia đình, phục vụ cho các nhu cầu cơ bản như nấu nướng, vệ sinh, giặt giũ và trang trí. Chúng bao gồm nhiều loại như đồ điện gia dụng (máy giặt, tủ lạnh, lò vi sóng), đồ dùng nhà bếp (nồi, chảo, bát đĩa), thiết bị vệ sinh (máy hút bụi, cây lau nhà), và các sản phẩm trang trí nội thất. Sản phẩm gia dụng giúp tối ưu hóa công việc trong nhà, mang lại sự tiện nghi và thoải mái cho người dùng.", "Gia dụng" },
                    { 3, "Sản phẩm điện tử là các thiết bị sử dụng công nghệ điện để hoạt động, đáp ứng nhu cầu giải trí, liên lạc, làm việc và học tập. Chúng bao gồm điện thoại di động, máy tính xách tay, máy tính bảng, tivi, tai nghe và các thiết bị gia dụng thông minh. Sản phẩm điện tử thường được trang bị các tính năng tiên tiến như kết nối internet, màn hình cảm ứng, và công nghệ không dây, giúp người dùng dễ dàng tương tác và cải thiện hiệu suất trong cuộc sống hàng ngày.", "Điện tử" },
                    { 4, "Sản phẩm thời trang bao gồm quần áo, giày dép, phụ kiện như túi xách, mũ, và trang sức, được thiết kế để thể hiện phong cách cá nhân và xu hướng thẩm mỹ. Chúng không chỉ đáp ứng nhu cầu mặc hàng ngày mà còn phản ánh cá tính, văn hóa, và thời đại. Các sản phẩm thời trang đa dạng từ trang phục công sở, dạo phố, đến trang phục dạ tiệc, thường được cập nhật liên tục theo mùa và xu hướng thời trang thế giới.", "Thời trang" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Seller" }
                });

            migrationBuilder.InsertData(
                table: "SaleEvents",
                columns: new[] { "Id", "Description", "Discount", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, "Giảm giá 20% cho tất cả các sản phẩm thời trang trong mùa hè này.", 0.2f, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khuyến Mãi Mùa Hè", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Giảm giá 15% cho các sản phẩm điện tử và công nghệ.", 0.15f, new DateTime(2024, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ngày Hội Công Nghệ", new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Giảm giá lên đến 30% cho tất cả các sản phẩm gia dụng và mỹ phẩm.", 0.3f, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khuyến Mãi Cuối Năm", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "Avatar", "CreatedAt", "Email", "Password", "Phone", "RoleId", "UpdatedAt", "VerifiedAt", "VerifyToken" },
                values: new object[,]
                {
                    { 1, "avatar1.jpg", new DateTime(2024, 9, 7, 16, 8, 42, 949, DateTimeKind.Local).AddTicks(6713), "admin@example.com", "$2a$11$NjJom1FqpljTknRVHFCv9./sUqUZgCpdfpRAn2TpIVLSwBBKw3BqO", "0912345678", 1, new DateTime(2024, 9, 17, 16, 8, 42, 949, DateTimeKind.Local).AddTicks(6722), new DateTime(2024, 9, 9, 16, 8, 42, 949, DateTimeKind.Local).AddTicks(6723), "token123" },
                    { 2, "avatar2.jpg", new DateTime(2024, 8, 28, 16, 8, 43, 84, DateTimeKind.Local).AddTicks(4936), "user1@example.com", "$2a$11$5yceO/ulTBfsUKYJQuFjROfZd8ycqbrCDniaCZYWzOBdyrMDYq6bq", "0934567890", 2, new DateTime(2024, 9, 17, 16, 8, 43, 84, DateTimeKind.Local).AddTicks(4977), null, "token456" },
                    { 3, "avatar3.jpg", new DateTime(2024, 9, 2, 16, 8, 43, 210, DateTimeKind.Local).AddTicks(3593), "user2@example.com", "$2a$11$8skXuGXLKMrbLMcqGw8E4eFPjhNu56GeTdf7485/.Tyu5sW2a/pd2", "0987654321", 2, new DateTime(2024, 9, 17, 16, 8, 43, 210, DateTimeKind.Local).AddTicks(3601), new DateTime(2024, 9, 7, 16, 8, 43, 210, DateTimeKind.Local).AddTicks(3602), "token789" },
                    { 4, "avatar4.jpg", new DateTime(2024, 9, 12, 16, 8, 43, 336, DateTimeKind.Local).AddTicks(4114), "seller1@example.com", "$2a$11$ts5nMXEqiDJqmMrE.RY29ebzGW8XCNPDpOiyliUPAbFkPreX0TB4S", "0901234567", 3, new DateTime(2024, 9, 17, 16, 8, 43, 336, DateTimeKind.Local).AddTicks(4122), null, "token101" },
                    { 5, "avatar5.jpg", new DateTime(2024, 8, 18, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(1246), "seller2@example.com", "$2a$11$AUsO4PdBIgHAhhVdqxGCcOk5/aNWTn8l6CjT6qiA1J7xzkCZvxAyG", "0912345678", 3, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(1256), new DateTime(2024, 8, 23, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(1258), "token202" }
                });

            migrationBuilder.InsertData(
                table: "CustomerTypeSaleEvents",
                columns: new[] { "CustomerTypeId", "SaleEventId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "AccountChatRooms",
                columns: new[] { "AccountId", "ChatRoomId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 1 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AccountId", "CustomerTypeId", "Description", "Dob", "Name" },
                values: new object[,]
                {
                    { 1, 2, 1, "Mô tả của khách hàng Nguyễn Văn A", new DateOnly(1990, 5, 10), "Nguyễn Văn A" },
                    { 2, 3, 2, "Khách hàng mới", new DateOnly(1985, 3, 15), "Trần Thị B" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "AccountId", "ChatRoomId", "Content", "CreatedAt", "IsRead" },
                values: new object[,]
                {
                    { 1, 2, 1, "Hello, how are you?", new DateTime(2024, 9, 17, 15, 58, 43, 468, DateTimeKind.Local).AddTicks(2264), true },
                    { 2, 4, 1, "I'm doing well, thank you!", new DateTime(2024, 9, 17, 15, 59, 43, 468, DateTimeKind.Local).AddTicks(2267), false },
                    { 3, 2, 1, "Did you finish the project?", new DateTime(2024, 9, 17, 16, 0, 43, 468, DateTimeKind.Local).AddTicks(2306), false },
                    { 4, 4, 1, "Yes, I submitted it yesterday.", new DateTime(2024, 9, 17, 16, 1, 43, 468, DateTimeKind.Local).AddTicks(2309), false },
                    { 5, 3, 2, "What time is the meeting?", new DateTime(2024, 9, 17, 16, 2, 43, 468, DateTimeKind.Local).AddTicks(2313), true },
                    { 6, 5, 2, "It's at 10 AM tomorrow.", new DateTime(2024, 9, 17, 16, 3, 43, 468, DateTimeKind.Local).AddTicks(2315), true },
                    { 7, 3, 2, "Can we reschedule the meeting?", new DateTime(2024, 9, 17, 16, 4, 43, 468, DateTimeKind.Local).AddTicks(2317), false },
                    { 8, 5, 2, "Sure, how about 11 AM?", new DateTime(2024, 9, 17, 16, 5, 43, 468, DateTimeKind.Local).AddTicks(2326), false },
                    { 9, 3, 2, "Let's catch up later.", new DateTime(2024, 9, 17, 16, 6, 43, 468, DateTimeKind.Local).AddTicks(2328), false }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "AccountId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 4, "\"Elegance Boutique\" là điểm đến lý tưởng cho những tín đồ yêu thích thời trang và mỹ phẩm chất lượng cao. Với sứ mệnh mang đến sự hoàn hảo trong từng sản phẩm, cửa hàng của chúng tôi chuyên cung cấp các mặt hàng thời trang và mỹ phẩm từ những thương hiệu danh tiếng, nổi bật với thiết kế tinh tế và phong cách hiện đại.\n\nTại \"Elegance Boutique\", bạn sẽ tìm thấy những bộ sưu tập thời trang đa dạng, từ các trang phục công sở thanh lịch, váy đầm quyến rũ đến những bộ đồ thể thao năng động, đáp ứng mọi nhu cầu và gu thẩm mỹ của khách hàng. Chúng tôi cam kết mang đến những sản phẩm thời trang được chọn lọc kỹ lưỡng từ các thương hiệu hàng đầu, với chất lượng vải tốt nhất và kiểu dáng thời thượng.\n\nBên cạnh thời trang, cửa hàng của chúng tôi còn nổi bật với bộ sưu tập mỹ phẩm cao cấp. Chúng tôi cung cấp các sản phẩm làm đẹp từ các thương hiệu nổi tiếng, bao gồm kem dưỡng da, son môi, sữa rửa mặt và nhiều sản phẩm chăm sóc sắc đẹp khác. Các sản phẩm mỹ phẩm tại \"Elegance Boutique\" được chọn lựa với tiêu chí an toàn, hiệu quả và phù hợp với mọi loại da, giúp bạn luôn tự tin và rạng rỡ.\n\nChúng tôi hiểu rằng việc mua sắm trực tuyến có thể là một trải nghiệm thú vị và thuận tiện, vì vậy cửa hàng của chúng tôi đã đầu tư vào nền tảng thương mại điện tử hiện đại. Bạn có thể dễ dàng duyệt qua các sản phẩm, thực hiện đơn hàng và nhận hàng ngay tại nhà với dịch vụ giao hàng nhanh chóng và bảo đảm. Hãy ghé thăm \"Elegance Boutique\" và khám phá thế giới thời trang và làm đẹp đỉnh cao ngay hôm nay!", "Elegance Boutique" },
                    { 2, 5, "\"Tech & Home Center\" là cửa hàng trực tuyến hàng đầu cung cấp các sản phẩm gia dụng và điện tử, được thiết kế để nâng cao chất lượng cuộc sống và đáp ứng nhu cầu công nghệ hiện đại của bạn. Chúng tôi tự hào mang đến cho khách hàng một trải nghiệm mua sắm tiện lợi và đa dạng với các sản phẩm chất lượng cao từ những thương hiệu uy tín.\n\nTại \"Tech & Home Center\", bạn sẽ tìm thấy một loạt các sản phẩm gia dụng thiết yếu cho ngôi nhà của bạn. Từ các thiết bị nhà bếp như máy xay sinh tố, nồi chiên không dầu, đến các thiết bị bảo trì và vệ sinh như máy hút bụi và máy lọc không khí, chúng tôi cung cấp những sản phẩm giúp bạn duy trì một môi trường sống sạch sẽ và tiện nghi.\n\nBên cạnh đó, chúng tôi còn cung cấp các thiết bị điện tử tiên tiến, bao gồm máy tính, điện thoại thông minh, TV và các phụ kiện công nghệ khác. Các sản phẩm điện tử của chúng tôi được chọn lựa từ các thương hiệu hàng đầu, đảm bảo hiệu suất vượt trội và tính năng hiện đại, đáp ứng nhu cầu giải trí, làm việc và kết nối của bạn.\n\n\"Tech & Home Center\" cam kết mang đến cho khách hàng một trải nghiệm mua sắm trực tuyến dễ dàng và thuận tiện. Với nền tảng thương mại điện tử tiên tiến, bạn có thể dễ dàng duyệt qua các sản phẩm, so sánh giá cả và đặt hàng chỉ với vài cú click chuột. Chúng tôi cung cấp dịch vụ giao hàng nhanh chóng và đáng tin cậy, cùng với chính sách đổi trả linh hoạt để đảm bảo sự hài lòng tuyệt đối của bạn.\n\nKhám phá \"Tech & Home Center\" ngay hôm nay để tìm kiếm những sản phẩm gia dụng và điện tử chất lượng cao, mang lại sự tiện lợi và hiệu suất tối ưu cho cuộc sống hàng ngày của bạn!", "Tech & Home Center" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressDetail", "CustomerId" },
                values: new object[,]
                {
                    { 1, "123 Đường Lê Lợi, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh", 1 },
                    { 2, "45 Ngõ 19, Phường Hàng Bài, Quận Hoàn Kiếm, Hà Nội", 1 },
                    { 3, "678 Đường Trần Hưng Đạo, Phường Tân Bình, Quận Tân Phú, TP. Hồ Chí Minh", 2 },
                    { 4, "32 Đường Nguyễn Thị Minh Khai, Phường 6, Quận 3, TP. Hồ Chí Minh", 2 }
                });

            migrationBuilder.InsertData(
                table: "CustomerNotifications",
                columns: new[] { "CustomerId", "NotificationId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "ProductTypeId", "Quantity", "ShopId" },
                values: new object[,]
                {
                    { 1, "Điện thoại thông minh với màn hình AMOLED và camera 108MP.", "Điện thoại thông minh Galaxy X12", 799.9m, 3, 50, 2 },
                    { 2, "Laptop cao cấp với màn hình 15 inch 4K và hiệu năng mạnh mẽ.", "Laptop Dell XPS 15", 1499.0m, 3, 30, 2 },
                    { 3, "Tai nghe không dây với công nghệ chống ồn và âm thanh chất lượng cao.", "Tai nghe Bluetooth AirPods Pro", 249.5m, 3, 100, 2 },
                    { 4, "Máy ảnh mirrorless với cảm biến full-frame và khả năng quay video 8K.", "Máy ảnh Canon EOS R5", 3899.0m, 3, 15, 2 },
                    { 5, "Áo sơ mi nam chất liệu cotton cao cấp, kiểu dáng cổ điển.", "Áo sơ mi nam Oxford", 59.9m, 4, 200, 1 },
                    { 6, "Váy đầm dành cho văn phòng với thiết kế tinh tế và thanh lịch.", "Váy đầm công sở thanh lịch", 89.0m, 4, 150, 1 },
                    { 7, "Giày thể thao cao cấp với đệm khí Boost, phù hợp cho vận động.", "Giày thể thao Adidas UltraBoost", 129.0m, 4, 80, 1 },
                    { 8, "Áo khoác giữ ấm với lông cừu mềm mại và kiểu dáng thời trang.", "Áo khoác lông cừu nữ", 150.0m, 4, 60, 1 },
                    { 9, "Máy lọc không khí hiệu suất cao với bộ lọc HEPA giúp không khí trong lành.", "Máy lọc không khí Philips", 199.9m, 2, 70, 2 },
                    { 10, "Tủ lạnh tiết kiệm năng lượng với dung tích 400L và công nghệ Inverter.", "Tủ lạnh LG Inverter 400L", 899.0m, 2, 25, 2 },
                    { 11, "Lò vi sóng với nhiều chế độ nấu và công suất mạnh mẽ.", "Lò vi sóng Panasonic", 79.9m, 2, 90, 2 },
                    { 12, "Máy giặt cửa trên với công nghệ giặt sạch hiệu quả và dung tích 7kg.", "Máy giặt Samsung 7kg", 399.0m, 2, 40, 2 },
                    { 13, "Kem dưỡng da ban đêm giúp cấp ẩm và làm sáng da.", "Kem dưỡng da Laneige", 65.0m, 1, 100, 1 },
                    { 14, "Son môi với chất lượng cao, màu sắc bền và không khô môi.", "Son môi MAC Matte", 25.0m, 1, 200, 1 },
                    { 15, "Sữa rửa mặt chiết xuất trà xanh giúp làm sạch da và giảm mụn.", "Sữa rửa mặt Innisfree", 18.0m, 1, 150, 1 }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "CustomerId", "ProductId", "CreatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 17, 16, 3, 43, 468, DateTimeKind.Local).AddTicks(3722) },
                    { 1, 2, new DateTime(2024, 9, 17, 16, 5, 43, 468, DateTimeKind.Local).AddTicks(3726) },
                    { 1, 8, new DateTime(2024, 9, 17, 15, 56, 43, 468, DateTimeKind.Local).AddTicks(3729) },
                    { 2, 5, new DateTime(2024, 9, 17, 15, 58, 43, 468, DateTimeKind.Local).AddTicks(3727) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "CreatedAt", "CustomerId", "PaymentStatus", "Status", "Total", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 12, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2982), 1, "Pending", "Processing", 250m, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2983) },
                    { 2, 2, new DateTime(2024, 9, 14, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2986), 1, "Completed", "Shipping", 120m, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2986) },
                    { 3, 3, new DateTime(2024, 9, 7, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2991), 2, "Completed", "Delivered", 75.9m, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2991) },
                    { 4, 4, new DateTime(2024, 9, 16, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2994), 2, "Pending", "Cancelled", 450.75m, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(2994) }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "Path", "ProductId" },
                values: new object[,]
                {
                    { 1, "product1_image1.jpg", 1 },
                    { 2, "product1_image2.jpg", 1 },
                    { 3, "product2_image1.jpg", 2 },
                    { 4, "product2_image2.jpg", 2 },
                    { 5, "product3_image1.jpg", 3 },
                    { 6, "product3_image2.jpg", 3 },
                    { 7, "product4_image1.jpg", 4 },
                    { 8, "product4_image2.jpg", 4 },
                    { 9, "product5_image1.jpg", 5 },
                    { 10, "product5_image2.jpg", 5 },
                    { 11, "product6_image1.jpg", 6 },
                    { 12, "product6_image2.jpg", 6 },
                    { 13, "product7_image1.jpg", 7 },
                    { 14, "product7_image2.jpg", 7 },
                    { 15, "product8_image1.jpg", 8 },
                    { 16, "product8_image2.jpg", 8 },
                    { 17, "product9_image1.jpg", 9 },
                    { 18, "product9_image2.jpg", 9 },
                    { 19, "product10_image1.jpg", 10 },
                    { 20, "product10_image2.jpg", 10 },
                    { 21, "product11_image1.jpg", 11 },
                    { 22, "product11_image2.jpg", 11 },
                    { 23, "product12_image1.jpg", 12 },
                    { 24, "product12_image2.jpg", 12 },
                    { 25, "product13_image1.jpg", 13 },
                    { 26, "product13_image2.jpg", 13 },
                    { 27, "product14_image1.jpg", 14 },
                    { 28, "product14_image2.jpg", 14 },
                    { 29, "product15_image1.jpg", 15 },
                    { 30, "product15_image2.jpg", 15 }
                });

            migrationBuilder.InsertData(
                table: "ProductSaleEvents",
                columns: new[] { "ProductId", "SaleEventId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 }
                });

            migrationBuilder.InsertData(
                table: "DetailOrders",
                columns: new[] { "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 2, 799.9m },
                    { 1, 2, 1, 1499.0m },
                    { 2, 3, 3, 249.5m },
                    { 3, 3, 1, 249.5m },
                    { 4, 4, 1, 3899.0m },
                    { 4, 5, 1, 59.9m }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "CustomerId", "OrderId", "ProductId", "Comment", "CreatedAt", "Score", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, "Sản phẩm chất lượng tốt, đáng giá tiền.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3416), 4, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3417) },
                    { 1, 1, 2, "Sản phẩm không như mong đợi, cần cải thiện.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3419), 3, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3419) },
                    { 1, 2, 3, "Dịch vụ tuyệt vời, sản phẩm hoàn hảo.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3421), 5, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3422) },
                    { 2, 3, 3, "Tốt nhưng cần cải thiện đóng gói.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3424), 4, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3424) },
                    { 2, 4, 4, "Sản phẩm bị lỗi, không hài lòng.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3426), 2, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3427) },
                    { 2, 4, 5, "Rất hài lòng với chất lượng và dịch vụ.", new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3429), 5, new DateTime(2024, 9, 17, 16, 8, 43, 468, DateTimeKind.Local).AddTicks(3429) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountChatRooms",
                keyColumns: new[] { "AccountId", "ChatRoomId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AccountChatRooms",
                keyColumns: new[] { "AccountId", "ChatRoomId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AccountChatRooms",
                keyColumns: new[] { "AccountId", "ChatRoomId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "AccountChatRooms",
                keyColumns: new[] { "AccountId", "ChatRoomId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerNotifications",
                keyColumns: new[] { "CustomerId", "NotificationId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerNotifications",
                keyColumns: new[] { "CustomerId", "NotificationId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerNotifications",
                keyColumns: new[] { "CustomerId", "NotificationId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CustomerNotifications",
                keyColumns: new[] { "CustomerId", "NotificationId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CustomerTypeSaleEvents",
                keyColumns: new[] { "CustomerTypeId", "SaleEventId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerTypeSaleEvents",
                keyColumns: new[] { "CustomerTypeId", "SaleEventId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerTypeSaleEvents",
                keyColumns: new[] { "CustomerTypeId", "SaleEventId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DetailOrders",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "Likes",
                keyColumns: new[] { "CustomerId", "ProductId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSaleEvents",
                keyColumns: new[] { "ProductId", "SaleEventId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1, 2 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 1, 2, 3 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 3, 3 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 4 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumns: new[] { "CustomerId", "OrderId", "ProductId" },
                keyValues: new object[] { 2, 4, 5 });

            migrationBuilder.DeleteData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ChatRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SaleEvents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SaleEvents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SaleEvents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
