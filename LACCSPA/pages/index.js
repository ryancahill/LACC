import axios from 'axios';
import Layout from '../components/Layout';

import Cigars from '../components/Cigars';

const Index = (props) => (
  <Layout>
    <div>
      <h1>Welcome to LACC Products Page</h1>
      <Cigars />
    </div>
  </Layout>
);

export default Index;