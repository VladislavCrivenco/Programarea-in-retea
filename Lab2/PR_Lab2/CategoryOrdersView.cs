public class CategoryOrdersView{
    private Dictionary<string, decimal> _categoriesOrders;
    private IProgress<CategoryOrdersView> _progress;

    public async Task<CategoryOrdersView> GetInstanceAsync(DateTime from, DateTime to, IProgress<CategoryOrdersView> progress){
        var inst = new CategoryOrdersView(progress);
        inst.Init(from, to);
    }

    private  CategoryOrdersView(IProgress<CategoryOrdersView> progress){
        _progress = progress ?? throw new ArgumentNullException();
    }
    
    private void Init(DateTime from, DateTime to){
        var orders = await Orders.Get(from, to);

        foreach (var order in orders)
        {
            if (!_categoriesOrders.Contains(order.Id)){
                _categoriesOrders[order.Id] = order.Total;
            }
            else
            {
                var currentTotal = _categoriesOrders[order.Id];
                _categoriesOrders[order.Id] = currentTotal + order.Total;
            }
        }

        _progress.Report(this);
    }

    public decimal Get(string orderId){
        if (!_categoriesOrders.Contains(orderId)){
            return 0;
        }

        return _categoriesOrders[orderId];
    }
}