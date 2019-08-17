import axios from 'axios';
import Router from 'next/router'

class Cigars extends React.Component {

  constructor(props) {
    super(props);
    this.state = {
      isLoading: true,
      testData: []
    };
  }

  componentDidMount() {
    this.interval = setInterval(this.getData, 10000);
    this.getData();
  }

  getData = () => {
    axios.get('http://localhost:55905/api/Cigars')
      .then((result) => {
        var removeIndex = result.data.map(function(item) { return item.id; }).indexOf(99);
        result.data.splice(removeIndex, 1);
        this.setState({
          testData: result.data,
          isLoading: false
        });
        console.log(this.state.testData);
      })
      .catch(error => {
        if (error.response) {
          console.log(error.responderEnd);
        }
      });
  }

  onChange(i, id) {
    axios.delete(`http://localhost:55905/api/Cigars/${id}`)
      .then(res => {
        console.log(res);
        console.log(res.data);
        this.getData();
      })
  };

  render() {
    if (this.props.isLoading) {
      return <span><i>Loading...</i></span>
    }
    else if (this.props.hasErrored) {
      return <span><b>Failed to load data: {this.props.errorMessage}</b></span>
    }
    else if (this.state.testData.length == 0) {
      return (<h3>There are no items to view. Please try back later.</h3>)
    }
    return (
      <center>
        <table cellPadding='15px'>
          <tbody>
            {this.state.testData.map((cigar, i) =>
              <tr key={cigar.name}>
                <td>
                  <img src={"static/" + cigar.name + ".jpg"} height={150} width={100} />
                  <br />
                  <button onClick={this.onChange.bind(this, i, cigar.id)}>Remove</button>
                </td>
                <td>
                  {cigar.name}<br />
                  {cigar.type}<br />
                  {cigar.description}<br />
                  {cigar.qty}
                </td>
              </tr>)}
          </tbody>
        </table>
      </center>
    );
  }
}

export default Cigars;